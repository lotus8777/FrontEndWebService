using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
using Newtonsoft.Json;

namespace FE.Handle.Request
{
    public class ExpenseInvoicesHandle : BasicHandle<ExpenseInvoicesIn>, IHandle
    {

        public ExpenseInvoicesHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {

        }

        /// <summary>
        ///     获取费用清单，在支付门诊或住院费用时使用
        /// </summary>
        /// <returns></returns>
        public string GetResultXml()
        {
            return string.IsNullOrEmpty(InPara.actnumber)
                ? throw new Exception("获取actnumber参数失败!")
                : string.IsNullOrEmpty(Config.YYBH)
                ? throw new Exception("获取医院编码失败")
                : string.IsNullOrEmpty(Config.CZGH)
                ? throw new Exception("获取操作工号失败")
                : InPara.acttype == 4 ? GetInpExpenseInvoices() : GetOpExpenseInvoices();
        }

        /// <summary>
        ///     住院病人费用清单
        /// </summary>
        /// <returns></returns>
        public string GetInpExpenseInvoices()
        {

            try
            {
                var patient = VerifyInpatient();
                var cvxCardType = GetCvxCardType(patient.Brxz.ToString(CultureInfo.InvariantCulture));
                if (cvxCardType != "08")
                {
                    var noUpload = Ctx.ZyFymxSet.Any(p => p.Zyh == patient.Zyh && p.Scbz == 0 && p.Jscs == 0);
                    if (noUpload)
                    {
                        throw new Exception("本次住院结算有未上传的明细记录");
                    }
                }

                var (cnt1, zjje1, zjje2) = GetInpFee(patient.Zyh, (int)(patient.Yepb ?? 0));
                //预交款
                var yjk = Ctx.ZyTbkkSet.Where(p => p.Zyh == patient.Zyh && p.Zfpb == 0 && p.Jscs == 0)
                    ?.Select(p => p.Jkje).DefaultIfEmpty(0).Sum();
                var clinic = GetInpClinicInfo(patient.Zyh, cnt1);
                var feeSummary = GetInpFeeSummary(patient.Zyh);

                var inpInvoices = new ExpenseInvoices
                {
                    Interface = new ExpenseInterface
                    {
                        HospitalCode = Config.YYBH,
                        Operator = Config.CZGH,
                        CVX_CardType = cvxCardType,
                        ICInfo = patient.Cardno ?? "",
                        YLLB = patient.Yllb,
                        FeeTotal = zjje1 + zjje2,
                        ZFFY = zjje2,
                        yjje = yjk.Value,
                        Clinic = clinic
                    }
                };
               var xml = ConvertToObject<ExpenseInvoices>.SerializeToXElement(inpInvoices);
                var listNode = xml.Descendants().FirstOrDefault(p => p.Name == "interface");
                var feeXElement = new XElement("zyfymx");
                foreach (var item in feeSummary)
                {
                    feeXElement.Add(new XElement($"I{item.K}", item.V));
                }

                listNode?.Add(feeXElement);
                return xml.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取住院费用失败! /r/n" + e.Message);
            }


        }

        /// <summary>
        ///     验证住院病人是否可以结算
        /// </summary>
        /// <returns></returns>
        private ZyBrry VerifyInpatient()
        {
            var patient = Ctx.ZyBrrySet.FirstOrDefault(p => p.Actnumber == InPara.actnumber);
            if (patient == null)
            {
                throw new Exception("获取住院病人档案失败");
            }

            if (patient.Cypb == 0)
            {
                throw new Exception("未完成出院证明操作");
            }

            if (patient.Cypb == 8)
            {
                throw new Exception("已完成出院结算");
            }

            if (patient.Cypb == 99)
            {
                throw new Exception("本次住院已注销");
            }

            if (patient.Xgpb == 2)
            {
                throw new Exception("正在进行费别转换2");
            }

            if (patient.Xgpb == 9)
            {
                throw new Exception("正在进行出院结算9");
            }

            if (patient.Ydjsbz == 0)
            {
                throw new Exception("该就诊信息移动结算检测未通过");
            }

            return patient;
        }

        private (int cnt1, decimal zjje1, decimal zjje2) GetInpFee(decimal zyh, int yepb)
        {
            int cnt1;
            var cnt2 = 0;
            decimal zjje1;
            decimal zjje2 = 0;
            var mx = Ctx.ZyFymxSet
                .Where(p => p.Jscs == 0 && p.Zyh == zyh)
                .GroupBy(p => p.Yefbz).Select(t => new
                {
                    yefbz = t.Key,
                    zjje = t.Sum(p => p.Zjje),
                    count = t.Count()
                });
            if (yepb == 1)
            {
                cnt1 = mx.Where(p => p.yefbz == 0).Sum(p => p.count);
                cnt2 = mx.Where(p => p.yefbz == 1).Sum(p => p.count);
                zjje1 = mx.Where(p => p.yefbz == 0).Sum(p => p.zjje);
                zjje2 = mx.Where(p => p.yefbz == 1).Sum(p => p.zjje);
            }
            else
            {
                cnt1 = mx.Sum(p => p.count);
                zjje1 = mx.Sum(p => p.zjje);
            }

            if (cnt2 + cnt1 == 0)
            {
                throw new Exception("本次住院结算无费用明细数据");
            }

            return (cnt1, zjje1, zjje2);
        }

        /// <summary>
        /// 获取临床信息
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private InpClinic GetInpClinicInfo(decimal zyh, int count)
        {
            try
            {
                var zyBrry = Ctx.ZyBrrySet.Where(p => p.Zyh == zyh)
                    .Include(p => p.GyYgdm)
                    .Include(p => p.KsBrks)
                    .Include(p => p.ZyRyzds.Select(t => t.GyJbbm)).FirstOrDefault();

             

                if (zyBrry != null)
                {
                    if (!zyBrry.ZyRyzds.Any())
                    {
                        throw new Exception("获取出入院诊断信息失败");
                    }
                    var disCode = zyBrry.ZyRyzds.FirstOrDefault(p => p.Zdlb == 3)?.GyJbbm.Icd9 ?? "";
                    var disName = zyBrry.ZyRyzds.FirstOrDefault(p => p.Zdlb == 3)?.GyJbbm.Jbmc ?? "";
                    //入院诊断，出院诊断
                    var cyzd = zyBrry.ZyRyzds.Where(p => p.Zdlb == 3 || p.Zdlb == 4).Select(p => p.GyJbbm.Icd9).ToList();
                    var clinic = new InpClinic
                    {
                        ClinicNo = zyBrry.Jzbh,
                        ClinicDate = zyBrry.Cyrq ?? DateTime.Now,
                        DeptCode = zyBrry.Brks.ToString(CultureInfo.InvariantCulture),
                        DeptGBCode = "",
                        DeptName = zyBrry.KsBrks.Ksmc ?? "",
                        DocName = zyBrry.GyYgdm.Ygxm ?? "",
                        DocSfzh = Ctx.HzybDmzdSet.FirstOrDefault(p => p.Dmlb == "YSDM_DZ" && p.Dmsb == zyBrry.Zzys)?.Dmmc ?? "",
                        DisCode = disCode,
                        DisName = disName,
                        DisDesc = "",
                        CYZD = cyzd,
                        FeeDetail = count
                    };
                    return clinic;
                }
                throw  new Exception("获取病人信息失败");
            }
            catch (Exception e)
            {
                throw new Exception("获取住院临床信息失败 /r/n" + e.Message);
            }
        }



        /// <summary>
        ///     获取住院费用分类信息
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <returns></returns>
        private dynamic GetInpFeeSummary(decimal zyh)
        {
            var query = Ctx.ZyFymxSet.Where(p => p.Zyh == zyh && p.Jscs == 0)
                .GroupBy(p => p.GySfxm.Zxgb)
                .Select(p => new { K = p.Key, V = p.Sum(t => t.Zjje) }).ToList();
            if (!query.Any())
            {
                throw new Exception("费用分类数据获取失败！");
            }

            return query;
        }

        /// <summary>
        ///     拼接门诊病人费用字符串
        /// </summary>
        /// <returns></returns>
        public string GetOpExpenseInvoices()
        {
            try
            {
                //获取病人信息
                var jzls = Ctx.YsMzJzlsSet.Where(p => p.Actnumber == InPara.actnumber && p.Zfpb == 0)
                    .Include(p => p.GyYgdm)
                    .Include(p => p.GyKsdm)
                    .Include(p => p.YsMzJbzds.Select(t => t.GyJbbm))
                    .OrderByDescending(p => p.Kssj).FirstOrDefault();
                if (jzls == null)
                {
                    throw new Exception("获取门诊就诊记录失败");
                }

                if (jzls.Brbh <= 0)
                {
                    throw new Exception("获取门诊病人档案失败");
                }

                var patient = Ctx.MsBrdaSet.Find(jzls.Brbh);
                if (patient == null || patient.Brxz <= 0)
                {
                    throw new Exception("获取病人基本信息失败");
                }

                var jbzd = jzls.YsMzJbzds.FirstOrDefault();

                if (jbzd == null)
                {
                    throw new Exception("没有诊断或诊断信息获取失败，请医生检查诊断信息");
                }

                var hzybDmzd = Ctx.HzybDmzdSet.FirstOrDefault(p => p.Dmlb == "YSDM_DZ" && p.Dmsb == jzls.Ysdm);
                var disCode = jbzd?.GyJbbm.Icd9 ?? "";
                var disName = jbzd?.GyJbbm.Jbmc ?? "";
                var cyzd = new List<string>
            {
                disCode
            };
                var clinic = new OpClinic()
                {
                    ClinicNo = jzls.Jzxh,
                    ClinicDate = jzls.Kssj,
                    DeptCode = jzls.Ksdm,
                    DeptGBCode = "",
                    DeptName = jzls.GyKsdm.Ksmc ?? "",
                    DocName = jzls.GyYgdm.Ygxm ?? "",
                    DocSfzh = hzybDmzd?.Dmmc ?? "",
                    DisCode = disCode,
                    DisName = disName,
                    DisDesc = "",
                    CYZD = cyzd,

                };

                //获取费用清单
                var details = GetOpFeeDetails(patient.Brid, (patient.Qybr ?? 0));
                clinic.FeeDetail = details.Select(p => p.Item.Count).DefaultIfEmpty(0).Sum();
                //组装xml语句
                var opExpense = new OpExpenseInvoices
                {
                    OpInterface = new OpExpenseInvoicesInterface
                    {
                        HospitalCode = Config.YYBH,
                        Operator = Config.CZGH,
                        CVX_CardType = GetCvxCardType(patient.Brxz.ToString()),
                        ICInfo = GetIcInfor(patient),
                        FeeTotal = details.Sum(p => p.itemCost),
                        Clinic = clinic,
                        list = details,
                        DisAudNo = "",
                        OperatorName = ""
                    }
                };
                return ConvertToObject<OpExpenseInvoices>.SerializeXmlToString(opExpense);
            }
            catch (Exception e)
            {
                throw new Exception("门诊费用清单获取失败！" + e.Message);
            }
        }

        /// <summary>
        ///     获取门诊费用详单
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="qybr"></param>
        /// <returns></returns>
        private List<OpFeeDetail> GetOpFeeDetails(decimal brid, decimal qybr)
        {
            var cfsj = DateTime.Now.AddDays(0 - Config.CFXQ);
            var webCfsj = DateTime.Now.AddDays(0 - Config.WebCFXQ);
            DateTime djsj;
            if (qybr == 1 || qybr == 5)
            {
                djsj = cfsj;
            }
            else
            {
                djsj = webCfsj;
            }

            //获取费用清单
            var feeList = new List<OpFeeDetail>();
            feeList.AddRange(GetRecipeFeeDetails(brid, qybr, cfsj, webCfsj));
            feeList.AddRange(GetTreatFeeDetails(brid, djsj));
            if (!feeList.Any())
            {
                throw new Exception("没有获取到费用清单");
            }

            return feeList;
        }

        /// <summary>
        /// 获取诊疗费用明细
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="cfsj"></param>
        /// <returns></returns>
        private IList<OpFeeDetail> GetTreatFeeDetails(decimal brid, DateTime cfsj)
        {

            var yjmx = Ctx.MsYj01Set.Where(p => p.Zfpb == 0 && p.Kdrq >= cfsj && p.Fphm == null && p.Cfbz < 2 && p.Brid == brid)
                .Include(p => p.MsYj02.Select(t => t.GyYlsf))
                .ToList();
            var feeList = new List<OpFeeDetail>();
            if (yjmx.Any())
            {
                var ylxhList = new List<Decimal>();
                foreach (var item in yjmx)
                {
                    if (item.MsYj02.Any())
                    {
                        yjmx.ForEach(p =>
                        {
                            var enumerator = p.MsYj02.Select(x => x.Ylxh).Distinct();
                            ylxhList.AddRange(enumerator);
                        });

                        IList<YbFydz> ybFydzes = new List<YbFydz>();
                        if (ylxhList.Any())
                        {
                            ybFydzes = Ctx.YbFydzSet.Where(p => ylxhList.Contains(p.Fyxh)).ToList();
                        }
                        List<OpFeeDetailItem> feeDetailItems = new List<OpFeeDetailItem>();
                        foreach (var sub in item.MsYj02)
                        {
                            var ybFydz = ybFydzes.FirstOrDefault(p =>
                                p.Fyxh == sub.Ylxh && p.Kssj <= item.Kdrq && (p.Zzsj == null || p.Zzsj >= item.Kdrq));
                            var fee = new OpFeeDetailItem
                            {
                                itemNumber = sub.Sbxh,
                                XMLB = 2,
                                SFLB = ybFydz?.Hzyb_Sflb ?? "",
                                DetailType = 2,
                                ItemCode = ybFydz?.Ybbm ?? "",
                                ItemHospCode = sub.Ylxh.ToString(CultureInfo.InvariantCulture),
                                ItemHospName = sub.GyYlsf.Fymc,
                                SDFlag = 0,
                                Price = sub.Yldj,
                                Amount = sub.Ylsl,
                                Amount_T = 1,
                                Unit = sub.GyYlsf.Fydw,
                                Spec = "",
                                MedType = "",
                                ItemTotal = sub.Hjje,
                                SelfDeal = 0,
                                SelfPay = 0,
                                SelfPayRate = 1,
                                DayTimes = "1",
                                Dosage = 1,
                                QEZFBZ = sub.Ybzfpb == 1 ? 1 : 0,
                                DisAudNo_DJ = sub.Spbh == null ? "" : sub.Spbh.ToString(),
                                Usage = ""
                            };
                            feeDetailItems.Add(fee);
                        }
                        var opFee = new OpFeeDetail
                        {
                            Type = 2,
                            Name = "诊疗费用",
                            itemNo = item.Yjxh,
                            itemCost = item.MsYj02.Sum(p => p.Hjje),
                            Item = feeDetailItems
                        };
                        feeList.Add(opFee);
                    }
                }
            }
            return feeList;
        }

        /// <summary>
        /// 获取处方费用明细
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="qybr"></param>
        /// <param name="cfsj"></param>
        /// <param name="webCfsj"></param>
        /// <returns></returns>
        private IList<OpFeeDetail> GetRecipeFeeDetails(decimal brid, decimal qybr, DateTime cfsj, DateTime webCfsj)
        {
            var cfmx = Ctx.MsCf01Set.Where(p => p.Zfpb == 0
                                                && p.Brid == brid
                                                && p.Fphm == null
                                                && p.Cfbz < 2
                                                && ((p.Kfrq >= cfsj
                                                && p.Fybz == 0)
                                                || (p.Fybz == 1 && p.Qybr == 1 && p.Kfrq >= webCfsj)))
                .Include(p => p.MsCf02.Select(t => t.YkTypk))
                .ToList();
            var feeList = new List<OpFeeDetail>();
            if (cfmx.Any())
            {
                var drugList = new List<decimal>();
                var ypyfList = new List<string>();
                var ypsxList = new List<string>();
                var gytjList = new List<decimal>();
                cfmx.ForEach(p =>
                {
                    var enumerable = p.MsCf02.Select(t => new { t.Ypxh, t.Ypyf, t.Gytj, t.YkTypk.Ypsx }).Distinct().ToList();
                    drugList.AddRange(enumerable.Select(x => x.Ypxh).Distinct());
                    ypsxList.AddRange(enumerable.Select(x => x.Ypsx.ToString()).Distinct());
                    ypyfList.AddRange(enumerable.Select(x => x.Ypyf).Distinct());
                    gytjList.AddRange(enumerable.Select(x => x.Gytj ?? 0).Distinct());
                });
                var ypdzNew = Ctx.YbYpdzNewSet.Where(p => drugList.Contains(p.Ypxh)).ToList();
                var hzybDmzds = Ctx.HzybDmzdSet.Where(p => (p.Dmlb == "YPJX_DZ" && ypsxList.Contains(p.Dmsb))
                                                          || (p.Dmlb == "SYPC_DZ" && ypyfList.Contains(p.Dmsb)))
                    .ToList();
                var zyYpyf = Ctx.ZyYpyfSet.Where(p => gytjList.Contains(p.Ypyf)).ToList();
                var feeItemList = new List<OpFeeDetailItem>();
                foreach (var item in cfmx)
                {
                    if (item.MsCf02.Any())
                    {

                        foreach (var sub in item.MsCf02)
                        {
                            var ypdz = ypdzNew.FirstOrDefault(p =>
                                p.Ypxh == sub.Ypxh && p.Kssj <= item.Kfrq &&
                                (p.Zzsj == null || p.Zzsj >= item.Kfrq));

                            var ypjx = hzybDmzds.FirstOrDefault(p =>
                                p.Dmlb == "YPJX_DZ" && p.Dmsb == sub.YkTypk.Ypsx.ToString());

                            var sypc = hzybDmzds.FirstOrDefault(p =>
                                 p.Dmlb == "SYPC_DZ" && p.Dmsb == sub.Ypyf);
                            var opFeeItem = new OpFeeDetailItem
                            {
                                itemNumber = sub.Sbxh,
                                XMLB = 1,
                                SFLB = ypdz?.Hzyb_Sflb ?? "", //填充数据
                                DetailType = 1,
                                ItemCode = ypdz?.Ybbm ?? "", //填充数据
                                ItemHospCode = $"{sub.Ypxh}-{sub.Ypcd}",
                                ItemHospName = sub.YkTypk.Ypmc,
                                Price = sub.Ypdj,
                                Amount = sub.Ypsl,
                                Amount_T = sub.Cfts,
                                Unit = sub.Yfdw,
                                Spec = sub.Yfgg ?? "",
                                MedType = ypjx?.Dmmc ?? "A001", //填充数据
                                ItemTotal = sub.Hjje,
                                SelfDeal = 0,
                                SelfPay = 0,
                                DayTimes = sypc?.Dmmc ?? "",//填充数据
                                Dosage = (sub.Ycjl ?? 0) / sub.YkTypk.Ypjl,//填充数据
                                SelfPayRate = 1,
                                QEZFBZ = sub.Ybzfpb ?? 0,
                                DisAudNo_DJ = sub.Spbh.ToString(),
                                Usage = "口服"
                            };
                            feeItemList.Add(opFeeItem);
                        }
                    }
                    var opFee = new OpFeeDetail
                    {
                        Type = 1,
                        Name = item.Cflx == 3 ? "草药方" : "西(成)药方",
                        itemNo = item.Cfsb,
                        itemCost = item.MsCf02.Sum(p => p.Hjje),
                        Item = feeItemList
                    };
                    feeList.Add(opFee);
                }
            }

            return feeList;
        }

        /// <summary>
        ///     返回医保类型代码
        /// </summary>
        /// <param name="brxz">病人性质</param>
        /// <returns></returns>
        public string GetCvxCardType(string brxz)
        {
            if (Config.HZYB_BRXZ == brxz || Config.WXYB_BRXZ == brxz)
            {
                return "02";
            }

            return "08";
        }

        /// <summary>
        ///     返回医保ic卡信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public string GetIcInfor(MsBrda patient)
        {
            var ickh = patient.Ickh ?? "";
            var ybkh = patient.Ybkh ?? "";
            var icxx = patient.Icxx ?? "";
            if (ickh.Length <= 30)
            {
                if (ybkh.Length >= 30)
                {
                    return ybkh;
                }

                if (icxx.Length > 100)
                {
                    return icxx.Trim().Substring(0, 50).Trim();
                }
            }

            return ickh;
        }

    }
}
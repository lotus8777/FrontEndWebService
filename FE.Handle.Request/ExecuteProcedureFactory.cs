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
    public class ExecuteProcedureFactory
    {
        private readonly JsonConfig Config;
        private readonly FrontEndContext Ctx;

        public ExecuteProcedureFactory(FrontEndContext context)
        {
            Ctx = context;
            Config = GetGenericConfig();
        }






        /// <summary>
        ///     获取住院费用清单
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetWsjFyqd(string inXmlStr)
        {
            try
            {
                var inPara = ConvertToObject<WsjFyqdGetIn>.XmlDeserialize(inXmlStr);
                if (inPara?.jssj == null || inPara?.kssj == null)
                {
                    throw new Exception("查询时间不能为空!");
                }

                var patient = Ctx.ZyBrrySet.Where(p => p.Actnumber == inPara.actnumber)
                    .Include(p => p.KsBrks)
                    .Include(p => p.ZyTbkks)
                    .Include(p => p.GyBrxz)
                    .Include(p => p.ZyFymxs)
                    .FirstOrDefault();
                if (patient == null)
                {
                    throw new Exception("不存在该序号的病人住院信息!");
                }

                var validList = patient.ZyFymxs.Where(p => p.Jfrq >= inPara.start && p.Jfrq < inPara.stop).ToList();
                var jbxx = new YyghInterfaceInterfaceJbxx
                {
                    brxm = patient.Brxm,
                    fyxz = patient.GyBrxz.Xzmc,
                    ryrq = patient.Ryrq,
                    cyrq = patient.Cyrq ?? DateTime.Now,
                    zyts = (int) ((patient.Cyrq ?? DateTime.Now) - patient.Ryrq).TotalDays,
                    brch = patient.Brch,
                    zyhm = patient.Zyhm,
                    ksmc = patient.KsBrks.Ksmc,
                    fyze = patient.ZyFymxs.Where(p => p.Jfrq <= inPara.stop).Sum(p => p.Zjje),
                    fyxj = validList.Sum(p => p.Zjje),
                    yjk = patient.ZyTbkks.Where(p => p.Zfpb == 0).Sum(p => p.Jkje)
                };
                var fyqd = validList.GroupBy(p => p.Fyxm)
                    .Select(t => new YyghInterfaceInterfaceItem
                    {
                        fylxdm = t.Key,
                        xmxj = t.Sum(a => a.Zjje),
                        zfxj = t.Sum(a => a.Zjje)
                    }).ToArray();

                var sfxmList = Ctx.GySfxmSet.ToList();

                foreach (var item in fyqd)
                {
                    item.fylxmc = sfxmList.FirstOrDefault(p => p.Sfxm == item.fylxdm)?.Sfmc;
                    item.fyitem = validList.Where(p => p.Fyxm == item.fylxdm)
                        .GroupBy(p => new {fyxh = p.Fyxh, fymc = p.Fymc, ypcd = p.Ypcd, fydj = p.Fydj, YPLX = p.Yplx})
                        .Select(p => new YyghInterfaceInterfaceItemFyitem
                        {
                            fydj = p.Key.fydj,
                            fymc = p.Key.fymc,
                            fysl = p.Sum(t => t.Fysl),
                            zfje = p.Sum(t => t.Zjje),
                            yblb = p.Key.YPLX,
                            fydm = p.Key.fyxh,
                            fyje = p.Sum(t => t.Zjje)
                        }).ToArray();
                }

                var outPara = new WsjFyqdGetOut
                {
                    RtnValue = 1,
                    bzxx = "获取住院费用清单成功",
                    FyqdGetInterface = new WsjFyqdGetInterface
                    {
                        jbxx = jbxx,
                        fyqd = fyqd
                    }
                };

                return ConvertToObject<WsjFyqdGetOut>.SerializeXmlToString(outPara);
            }
            catch (Exception e)
            {
                throw new Exception("获取住院清单失败"+e.Message);
            }
        }

    





        /// <summary>
        ///     获取某个科室所有医生排班状态
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetKsYsPb(string inXml)
        {
            XElement root;
            var xml = XElement.Parse(inXml);
            var ksdm = xml.Element("ksdm")?.Value;
            var ksrq = Convert.ToDateTime(xml.Element("ksrq")?.Value);
            var zzrq = Convert.ToDateTime(xml.Element("zzrq")?.Value);
            var list = GetKsyspb(ksdm, ksrq, zzrq);
            var interfaceXml = new XElement("interface");
            foreach (var item in list)
            {
                interfaceXml.Add(item.ToXml("row"));
            }

            root = new XElement("YyghInterface",
                new XElement("RtnValue", 1),
                new XElement("bzxx"),
                interfaceXml
            );

            return root.ToString();
        }

        private IList<ksyspb> GetKsyspb(string ksdm, DateTime kssj, DateTime jssj)
        {
            try
            {
                return Ctx.Database.SqlQuery<ksyspb>($"exec proc_wjj_yspb '{ksdm}','{kssj}','{jssj}'").ToList();
            }
            catch (Exception e)
            {
                throw new Exception("获取科室所有医生排班信息失败" + e.Message);
                
            }
        }



        public string GetMzGhksXml(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = Ctx.Database.SqlQuery<WsjGhks>("exec proc_get_ghks").Where(p => p.kfyypb == mode).ToList();
            if (query.Any())
            {
                var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", ""),
                        new XElement("interface")
                    ));
                query.ForEach(p => { document.Root?.Element("interface")?.Add(p.ToXml()); });
                rtnXml = document.ToString();
            }
            else
            {
                rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }

            return rtnXml;
        }

        /// <summary>
        ///     获取费用清单，在支付门诊或住院费用时使用
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetExpenseInvoice(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var actType = xml.Element("acttype")?.Value;
            var actNumber = xml.Element("actnumber")?.Value;
            if (string.IsNullOrEmpty(actNumber))
            {
                throw new Exception("获取actnumber参数失败!");
            }
            //var jzlsh = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "jzlsh")?.Value;
            //var mzzyhm = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "mzzyhm")?.Value;
            if (string.IsNullOrEmpty(Config.YYBH))
            {
                throw new Exception("获取医院编码失败");
            }

            if (string.IsNullOrEmpty(Config.CZGH))
            {
                throw new Exception("获取操作工号失败");
            }

            return actType == "4" ? GetInpExpenseInvoices(actNumber) : GetOpExpenseInvoices(actNumber);
        }

        /// <summary>
        ///     住院病人费用清单
        /// </summary>
        /// <returns></returns>
        public string GetInpExpenseInvoices(string actNumber)
        {
            XElement xml;
            try
            {
                var patient = VerifyInpatient(actNumber);
                var cvxCardType = GetCvxCardType(patient.Brxz.ToString(CultureInfo.InvariantCulture));
                if (cvxCardType != "08")
                {
                    var noUpload = Ctx.ZyFymxSet.Any(p => p.Zyh == patient.Zyh && p.Scbz == 0 && p.Jscs == 0);
                    if (noUpload)
                    {
                        throw new Exception("本次住院结算有未上传的明细记录");
                    }
                }

                var (cnt1, zjje1, zjje2) = GetInpFee(patient.Zyh, (int) (patient.Yepb ?? 0));
                //预交款
                var yjk = Ctx.ZyTbkkSet.Where(p => p.Zyh == patient.Zyh && p.Zfpb == 0 && p.Jscs == 0)
                    ?.Select(p => p.Jkje).DefaultIfEmpty(0).Sum();
                var clinic = GetInpClinicInfo(patient.Zyh, cnt1);
                var feeSummary = GetInpFeeSummary(patient.Zyh);

                var inpInvoices = new InpExpenseInvoices
                {
                    InpInterface = new InpExpenseInvoicesInterface
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
                xml = ConvertToObject<InpExpenseInvoices>.SerializeToXElement(inpInvoices);
                var listNode = xml.Descendants().FirstOrDefault(p => p.Name == "interface");
                var feeXElement = new XElement("zyfymx");
                foreach (var item in feeSummary)
                {
                    var arr = item.Split('-');
                    feeXElement.Add(new XElement($"I{arr[0]}", arr[1]));
                }

                listNode?.Add(feeXElement);
            }
            catch (Exception e)
            {
                throw new Exception("获取住院费用失败!->"+e.Message);
            }

            return xml.ToString();
        }

        /// <summary>
        ///     验证住院病人是否可以结算
        /// </summary>
        /// <param name="actNumber">唯一代码</param>
        /// <returns></returns>
        private ZyBrry VerifyInpatient(string actNumber)
        {
            var patient = Ctx.ZyBrrySet.FirstOrDefault(p => p.Actnumber == actNumber);
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

        private (int cnt1, decimal zjje1, decimal zjje2) GetInpFee(int zyh, int yepb)
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

        private InpClinic GetInpClinicInfo(int zyh, int count)
        {
            var clinic = Ctx.Database.SqlQuery<InpClinic>($"exec proc_wjj_inclinic {zyh}").FirstOrDefault();
            if (clinic == null)
            {
                throw new Exception("获取住院相关信息失败");
            }
            //获取诊断
            clinic.CYZD = GetInpClinicDiagnose(zyh).ToArray();
            clinic.FeeDetail = count;
            return clinic;
        }

        /// <summary>
        ///     获取住院病人临床诊断
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private IList<string> GetInpClinicDiagnose(int zyh)
        {
            var sql = $@"SELECT
                              gj.ICD9 AS ICD9
                            FROM zy_ryzd zr
                                ,gy_jbbm gj
                            WHERE zr.ZDXH = gj.jbxh
                            AND zr.ZYH = {zyh}
                            AND zr.zdlb IN (3, 4)";
            var query = Ctx.Database.SqlQuery<string>(sql).ToList();
            if (!query.Any())
            {
                throw new Exception("出入院诊断获取失败！");
            }

            return query;
        }

        /// <summary>
        ///     获取住院费用分类信息
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <returns></returns>
        private IList<string> GetInpFeeSummary(int zyh)
        {
            var sql = $@"select (ISNULL(gs.zxgb, '99'))+'-'+ CAST(SUM(zf.zjje) AS VARCHAR)
                            FROM zy_fymx zf,gy_sfxm gs
                            WHERE zf.fyxm = gs.sfxm
                            AND zf.zyh = {zyh}
                            AND zf.jscs =0
                            GROUP BY gs.zxgb";
            var query = Ctx.Database.SqlQuery<string>(sql).ToList();
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
        public string GetOpExpenseInvoices(string actNumber)
        {
            // XElement xml;
            //获取病人信息
            var jzls = Ctx.YsMzJzlsSet.Where(p => p.Actnumber == actNumber && p.Zfpb == 0)
                .OrderByDescending(p => p.Kssj).FirstOrDefault();
            if (jzls == null)
            {
                throw new Exception("获取门诊就诊记录失败");
            }

            if (jzls.Brbh <= 0)
            {
                throw new Exception("获取门诊病人档案失败");
            }

            var patient = Ctx.MzBrdaSet.Find(jzls.Brbh);
            if (patient == null || patient.Brxz <= 0)
            {
                throw new Exception("获取病人基本信息失败");
            }

            var clinic = Ctx.Database.SqlQuery<OpClinic>($"exec proc_wjj_outclinic {jzls.Jzxh}").FirstOrDefault();
            if (clinic == null)
            {
                throw new Exception("获取门诊clinic信息失败");
            }

            if (string.IsNullOrEmpty(clinic.DisName) || string.IsNullOrEmpty(clinic.DisCode))
            {
                throw new Exception("没有诊断或诊断信息获取失败，请医生检查诊断信息");
            }

            clinic.CYZD = new List<string>
            {
                clinic.DisCode
            };

            //获取费用清单
            var details = GetOpFeeDetails((int) patient.Brid, (int) (patient.Qybr ?? 0));
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
            return ConvertToObject<OpExpenseInvoices>.SerializeToXElement(opExpense).ToString();
        }

        /// <summary>
        ///     获取门诊费用详单
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="qybr"></param>
        /// <returns></returns>
        private List<OpFeeDetail> GetOpFeeDetails(int brid, int qybr)
        {
            var cfsj = DateTime.Now.AddDays(0 - Config.CFXQ);
            var webCfsj = DateTime.Now.AddDays(0 - Config.WebCFXQ);
            DateTime djsj1;
            if (qybr == 1 || qybr == 5)
            {
                djsj1 = cfsj;
            }
            else
            {
                djsj1 = webCfsj;
            }

            //获取费用清单
            var sql = $"exec proc_wjj_cfyj {brid},'{cfsj}','{webCfsj}','{djsj1}'";
            var list = Ctx.Database.SqlQuery<OpFeeDetail>(sql).ToList();
            if (list.Any())
            {
                try
                {
                    foreach (var opFee in list)
                    {
                        if (opFee.Type == 1)
                        {
                            opFee.Item = Ctx.Database.SqlQuery<OpFeeDetailItem>($"exec proc_wjj_cfmx {opFee.itemNo}")
                                .ToList();
                        }
                        else
                        {
                            opFee.Item = Ctx.Database.SqlQuery<OpFeeDetailItem>($"exec proc_wjj_yjmx {opFee.itemNo}")
                                .ToList();
                        }

                        if (opFee.Item.Any())
                        {
                            opFee.itemCost = opFee.Item.Sum(p => p.ItemTotal);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("获取处方或检查明细失败" + e.Message);
                }
            }
            else
            {
                throw new Exception("没有获取到费用清单");
            }

            return list;
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

        public string GetCodePayXml(string inXmlStr)
        {
            var yyjsls = string.Empty;
            try
            {
                var xml = XElement.Parse(inXmlStr);
                yyjsls = xml.Element("yyjsls")?.Value;
                var pay = Convert.ToDecimal(xml.Element("pay")?.Value);
                var zffs = xml.Element("zffs")?.Value;
                try
                {
                    var fkrz = new PayFkrz
                    {
                        Jydm = "hos_codepay",
                        Jylx = "1",
                        Yyjsls = yyjsls,
                        Xrrq = DateTime.Now,
                        Instr = inXmlStr
                    };
                    Ctx.PayFkrzSet.Add(fkrz);
                    Ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("业务日志保存失败/r/n" + e.Message);
                }

                var record = Ctx.PayFkjlSet.Find(yyjsls);
                if (record == null)
                {
                    throw new Exception("PAY_FKJL查询失败");
                }

                if (record.Zfpb != 0)
                {
                    throw new Exception("该记录已作废");
                }

                if (record.State == 1)
                {
                    var outXml = ReturnXml(1, "已经成功", null);
                    var fkrz = new PayFkrz
                    {
                        Jydm = "hos_codepay",
                        Jylx = "2",
                        Yyjsls = yyjsls,
                        Xrrq = DateTime.Now,
                        Instr = outXml
                    };
                    Ctx.PayFkrzSet.Add(fkrz);
                    Ctx.SaveChanges();
                    return outXml;
                }

                if (record.State == -1)
                {
                    throw new Exception("该记录已冲正");
                }

                //更新PAY_FKJL表状态失败
                try
                {
                    record.Pay2 = pay;
                    record.Zffs = zffs;
                    record.State = 1;
                    Ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("更新PAY_FKJL表状态失败/r/n" + e.Message);
                }

                return ReturnXml(1, "成功", null);
            }
            catch (Exception e)
            {
                var outXml = ReturnXml(-1, "hos_codepay" + e.Message, null);
                var fkrz = new PayFkrz
                {
                    Jydm = "hos_codepay",
                    Jylx = "2",
                    Yyjsls = yyjsls,
                    Xrrq = DateTime.Now,
                    Instr = outXml
                };
                Ctx.PayFkrzSet.Add(fkrz);
                Ctx.SaveChanges();
                throw;
            }
        }

        private string ReturnXml(int rtnValue, string bzxx, string data)
        {
            var xmlElement =
                new XElement("YyghInterface",
                    new XElement("RtnValue", rtnValue),
                    new XElement("bzxx", bzxx)
                );
            if (data != null)
            {
                xmlElement.Add(new XElement("interface", data));
            }

            return xmlElement.ToString();
        }

        private JsonConfig GetGenericConfig()
        {
            var path = $@"{AppContext.BaseDirectory}\appConfig.json";
            return JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText(path));
        }

        private IList<XElement> GetXmlNodes(string xmlString)
        {
            var xml = XElement.Parse(xmlString);
            return xml.Descendants().ToList();
        }


        /// <summary>
        ///     获取当前排班记录序号
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetQdJzxh(string inXmlStr)
        {
            try
            {
                var nodeList = GetXmlNodes(inXmlStr);
                var ghlb = Convert.ToInt32(nodeList.FirstOrDefault(p => p.Name == "ghlb")?.Value);
                var ksdm = nodeList.FirstOrDefault(p => p.Name == "ksdm")?.Value;
                var gzrq = Convert.ToDateTime(nodeList.FirstOrDefault(p => p.Name == "gzrq")?.Value);
                var ysdm = nodeList.FirstOrDefault(p => p.Name == "ysdm")?.Value;
                var zblb = Convert.ToInt32(nodeList.FirstOrDefault(p => p.Name == "zblb")?.Value);
                var yspb = Ctx.MzYspbSet.FirstOrDefault(p => p.Ksdm == ksdm
                                                              && p.Ysdm == ysdm
                                                              && p.Zblb == zblb
                                                              && p.Gzrq == gzrq
                                                              && p.MzGhks.Ghlb == ghlb);
                if (yspb == null)
                {
                    throw new Exception("获取排班信息失败！");
                }

                var root = new XElement("YyghInterface",
                    new XElement("RtnValue", 1),
                    new XElement("bzxx"),
                    new XElement("interface",
                        new XElement("dqcx", yspb.Jzxh))
                );
                return root.ToString(SaveOptions.DisableFormatting);
            }
            catch (Exception e)
            {
                throw new Exception("取就诊序号时发生错误->"+e.Message);
            }
        }

       
    }
}
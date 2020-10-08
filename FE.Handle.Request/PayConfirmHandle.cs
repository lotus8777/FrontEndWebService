using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace FE.Handle.Request
{
    public class PayConfirmHandle : BasicHandle<HosPayConfirmIn>
    {
        //private HosPayConfirmIn InPara;

        public PayConfirmHandle(FrontEndContext context, string inXmlStr) : base(context,inXmlStr)
        {
            //InPara = ConvertToObject<HosPayConfirmIn>.XmlDeserialize(inXmlStr);
            ValidateHosPayConfirmIn();
        }

        /// <summary>
        ///     病人结算处理
        /// </summary>
        /// <returns></returns>
        public string GetPayConfirm()
        {
            if (InPara.actnumber == "4")
            {
                return GetInpPayConfirm();
            }
            return GetOpPayConfirm();
        }

        /// <summary>
        ///     门诊病人确认支付逻辑处理
        /// </summary>
        /// <returns></returns>
        private string GetOpPayConfirm()
        {
            using (var transaction = Ctx.Database.BeginTransaction())
            {
                try
                {
                    var jzls = Ctx.YsMzJzlsSet.Where(p => p.Actnumber == InPara.actnumber)
                        .OrderByDescending(p => p.Kssj)
                        .FirstOrDefault();
                    if (jzls == null)
                    {
                        throw new Exception("获取就诊记录失败！");
                    }

                    var brid = jzls.Brbh;
                    var brda = Ctx.MzBrdaSet.Find(brid);
                    if (string.IsNullOrEmpty(brda?.Brxm))
                    {
                        throw new Exception("获取病人基本信息失败！");
                    }

                    var identity = GetOpIdentityKey();
                    InPara.OtherPara = new OtherPayConfirmPara()
                    {
                        YsMzJzls_Jzxh = jzls.Jzxh,
                        Fphm = $"YD{InPara.PayLSH}",
                        Sjhm = $"YD{InPara.PayLSH}",
                        MsMzxx_Mzxh = identity.mzxh,
                        BocJsjl_Jlxh = identity.jlxh,
                        Jzlx = 2
                    };

                    if (InPara.YbJsxx.CVX_CardType == "02")
                    {
                        InPara.OtherPara.Brxz = Convert.ToInt32(Config.HZYB_BRXZ);
                        InPara.OtherPara.Ybpb = 1;
                    }

                    //InPara.OtherPara.HzybJsjl_Jylsh = identity.jylsh;

                    //判断节点数据
                    var gyXtcsSet = Ctx.GyXtcsSet.Where(p => (p.Csmc == "XYF"
                                                               || p.Csmc == "CYF"
                                                               || p.Csmc == "ZYF")
                                                              && p.Xtsb == 0).ToList();
                    if (!gyXtcsSet.Any() && gyXtcsSet.Count != 3)
                    {
                        throw new Exception("药费费用归并错误，请联系HIS管理员维护正确信息！");
                    }
                    InsertMsMzxx(brda);
                    //临时表数据获取
                    var msSfmxSet = Ctx.MsSfmxSet.Where(p => p.Mzxh == InPara.OtherPara.MsMzxx_Mzxh).ToList();
                    foreach (var item in InPara.fyqd.list)
                    {
                        if (item.Type == 1)
                        {
                            DisposeRecipe(item, msSfmxSet, gyXtcsSet);
                        }
                        else
                        {
                            //诊疗费用
                            DisposeTreatment(item, msSfmxSet);
                        }
                    }

                    //插入医保结算数据

                    InsertHzybJsjl();
                    InsertBocJsjl();
                    var xml = GetOpResultXmlString();
                    //throw new Exception("ceshishi");
                    transaction.Commit();
                    return xml;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("门诊结算失败"+e.Message);
                }
            }
        }

        private void InsertMsMzxx(MsBrda brda)
        {
            //插入ms_mzxx
            var mzxx = new MsMzxx
            {
                Mzxh = InPara.OtherPara.MsMzxx_Mzxh,
                Fphm = InPara.OtherPara.Fphm,
                Sfrq = DateTime.Now,
                Brid = brda.Brid,
                Brxm = brda.Brxm,
                Brxb = brda.Brxb,
                Brxz = InPara.OtherPara.Brxz,
                Zhje = InPara.PayJsxx.Bxje,
                Zjje = InPara.PayJsxx.Fyze,
                Mzlb = 1,
                Qybr = 1,
                Ylje = InPara.PayJsxx.Zfje,
                Czgh = Config.CZGH,
                Paylsh = InPara.PayLSH,
                Sjfp = InPara.OtherPara.Fphm,
                Jkda = 1,
                Dzpj = InPara.ElectronicInvoiceNumber,
                Zfpb = 0,
                Sffs = InPara.PayJsxx.PayMethod
            };
            Ctx.MsMzxxSet.Add(mzxx);
            Ctx.SaveChanges();
        }

        private void DisposeRecipe(InterfaceFyqdDetail item, IList<MsSfmx> msSfmxSet, IList<GyXtcs> gyXtcsSet)
        {
            var cf01 = Ctx.MsCf01Set.Where(p => p.Cfsb == item.itemNo).Include(p => p.MsCf02).FirstOrDefault();
            if (cf01 == null)
            {
                throw new Exception("处方信息不存在，请重试！");
            }

            if (!string.IsNullOrEmpty(cf01.Fphm))
            {
                throw new Exception($"处方{item.itemNo}已经进行了结算，不能重复结算！");
            }

            if (!cf01.MsCf02.Any())
            {
                throw new Exception($"处方{item.itemNo}没有药品信息，请医生检查开方内容！");
            }
            //单据金额
            var hisItemCost = cf01.MsCf02.Sum(p => p.Hjje);
            if (Math.Abs(item.itemCost - hisItemCost) > (decimal)0.05)
            {
                throw new Exception("传入处方金额与HIS不符，无法结算，请重试！");
            }

            cf01.Fphm = InPara.OtherPara.Fphm;
            cf01.Mzxh = InPara.OtherPara.MsMzxx_Mzxh;
            cf01.Jzxh = InPara.OtherPara.YsMzJzls_Jzxh;
            if (InPara.OtherPara.Ybpb == 1)
            {
                foreach (var detail in item.item)
                {
                    var cf02 = cf01.MsCf02.FirstOrDefault(p => p.Sbxh == detail.itemNumber);
                    if (cf02 != null)
                    {
                        cf02.Tsxx = detail.BZXX;
                        cf02.Zfbl = detail.SelfPayRate;
                    }
                }
            }
            //产生单据明细计算信息及医保分类明细临时表数据MS_SFMX,WXYB_FLMX,WXYB_JSMX
            var sfxm = GetChargeType(gyXtcsSet, cf01.Cflx);
            var temp = msSfmxSet.FirstOrDefault(p => p.Sfxm == sfxm);
            if (temp == null)
            {
                temp = new MsSfmx
                {
                    Mzxh = InPara.OtherPara.MsMzxx_Mzxh,
                    Sfxm = sfxm,
                    Zjje = hisItemCost,
                    Zfje = item.item.Sum(p => p.SelfPay),
                    Fphm = InPara.OtherPara.Fphm,
                    Jgid = 1
                };
                Ctx.MsSfmxSet.Add(temp);
            }
            else
            {
                temp.Zjje += hisItemCost;
                temp.Zfje += 0;
            }
            Ctx.SaveChanges();
        }

        /// <summary>
        /// 获取处方的收费项目1西药2中药3成药
        /// </summary>
        /// <param name="gyXtcsSet"></param>
        /// <param name="cflx"></param>
        /// <returns></returns>
        private decimal GetChargeType(IList<GyXtcs> gyXtcsSet, decimal cflx)
        {
            string strSfxm;
            if (cflx == 1)
            {
                strSfxm = gyXtcsSet.FirstOrDefault(p => p.Csmc == "XYF")?.Csz;
            }
            else if (cflx == 2)
            {
                strSfxm = gyXtcsSet.FirstOrDefault(p => p.Csmc == "ZYF")?.Csz;
            }
            else
            {
                strSfxm = gyXtcsSet.FirstOrDefault(p => p.Csmc == "CYF")?.Csz;
            }
            return Convert.ToDecimal(strSfxm);
        }

        /// <summary>
        /// 处理诊疗类项目
        /// </summary>
        private void DisposeTreatment(InterfaceFyqdDetail item, IList<MsSfmx> msSfmxSet)
        {
            //诊疗费用
            var yj01 = Ctx.MsYj01Set.Where(p => p.Yjxh == item.itemNo).Include(p => p.MsYj02).FirstOrDefault();
            if (yj01 == null)
            {
                throw new Exception("检查单信息不存在，请重试！");
            }

            if (!string.IsNullOrEmpty(yj01.Fphm))
            {
                throw new Exception($"检查单{item.itemNo}已经进行了结算，不能重复结算！");
            }

            if (!yj01.MsYj02.Any())
            {
                throw new Exception($"检查单{item.itemNo}没有检查项目，请医生检查开单内容！");
            }
            //his单据金额
            var hisItemCost = yj01.MsYj02.Sum(p => p.Hjje);
            if (Math.Abs(item.itemCost - hisItemCost) > (decimal)0.05)
            {
                throw new Exception("传入检查单金额与HIS不符，无法结算，请重试！");
            }

            yj01.Fphm = InPara.OtherPara.Fphm;
            yj01.Mzxh = InPara.OtherPara.MsMzxx_Mzxh;
            yj01.Jzxh = InPara.OtherPara.YsMzJzls_Jzxh;
            //存在ms_ykkdyz则更新fphm字段，目前我院不存在医技开单
            if (InPara.OtherPara.Ybpb == 1)
            {
                foreach (var detail in item.item)
                {
                    var yj02 = yj01.MsYj02.FirstOrDefault(p => p.Sbxh == detail.itemNumber);
                    if (yj02 != null)
                    {
                        yj02.Tsxx = detail.BZXX;
                        yj02.Zfbl = detail.SelfPayRate;
                    }
                }
            }
            //修改或插入MS_SFMX
            foreach (var yj in yj01.MsYj02)
            {
                var temp = msSfmxSet.FirstOrDefault(p => p.Sfxm == yj.Fygb);
                if (temp == null)
                {
                    temp = new MsSfmx
                    {
                        Mzxh = InPara.OtherPara.MsMzxx_Mzxh,
                        Sfxm = yj.Fygb,
                        Zjje = hisItemCost,
                        Zfje = yj.Hjje * yj.Zfbl,
                        Fphm = InPara.OtherPara.Fphm,
                        Jgid = 1
                    };
                    Ctx.MsSfmxSet.Add(temp);
                }
                else
                {
                    temp.Zjje += hisItemCost;
                    temp.Zfje += yj.Hjje * yj.Zfbl;
                }
            }
            Ctx.SaveChanges();
        }

        /// <summary>
        /// 获取最终输出值
        /// </summary>
        /// <returns></returns>
        private string GetOpResultXmlString()
        {
            //var query = from a in _ctx.MsSfmxSet.Where(p => p.MsMzxx_Mzxh == InPara.OtherPara.MsMzxx_Mzxh)
            //            join b in _ctx.GySfxmSet on a.Sfxm equals b.Sfxm into abJoin
            //            from t in abJoin.DefaultIfEmpty()
            //            select new { t.Zxgb, a.Zjje }
            //    into f
            //            group f by f.Zxgb
            //    into tGroup
            //            select new { Item = tGroup.Key, Zjje = tGroup.Sum(y => y.Zjje) };
            var query = Ctx.MsSfmxSet.Where(p => p.Mzxh == InPara.OtherPara.MsMzxx_Mzxh).Include(p => p.GySfxm)
                .GroupBy(p => p.GySfxm.Zxgb)
                .Select(p => new { Key = p.Key, Zjje = p.Sum(t => t.Zjje) })
                .ToList();
            var xml = new XElement("YyghInterface",
                new XElement("RtnValue", 1),
                new XElement("bzxx", "门诊结算成功"),
                new XElement("yyjsls", InPara.OtherPara.Fphm)
            );
            var mzfymx = new XElement("mzfymx");
            foreach (var item in query.ToList())
            {
                var key = string.IsNullOrEmpty(item.Key) ? "I99" : $"I{item.Key}";
                mzfymx.Add(new XElement(key, item.Zjje));
            }
            xml.Add(mzfymx);
            return xml.ToString();
        }

        private string GetInpResultXmlString(int zyh)
        {
            var query = Ctx.ZyJsmxSet
                .Where(p => p.Zyh == zyh && p.Jscs == InPara.OtherPara.Jscs)
                //.Include(p => p.GySfxm)
                .GroupBy(p => p.GySfxm.Zxgb)
                .Select(p => new { Key = p.Key, Zjje = p.Sum(t => t.Zjje) })
                .ToList();
            var xml = new XElement("YyghInterface",
                new XElement("RtnValue", 1),
                new XElement("bzxx", "住院结算成功"),
                new XElement("yyjsls", InPara.OtherPara.Fphm)
            );
            var zyfymx = new XElement("zyfymx");
            foreach (var item in query.ToList())
            {
                var key = string.IsNullOrEmpty(item.Key) ? "I99" : $"I{item.Key}";
                zyfymx.Add(new XElement(key, item.Zjje));
            }
            xml.Add(zyfymx);
            return xml.ToString();
        }

        /// <summary>
        /// 插入Boc_Jsjl表
        /// </summary>
        private void InsertBocJsjl()
        {
            var bocJsjl = new BocJsjl
            {
                Jlxh = InPara.OtherPara.BocJsjl_Jlxh,
                Fphm = InPara.OtherPara.Sjhm,
                Jzlsh = InPara.PayLSH,
                Jslx = InPara.PayJsxx.PayMethod + 3,
                Jzlx = InPara.OtherPara.Jzlx,
                Jyje = InPara.PayJsxx.Zfje,
                Jyrq = Convert.ToDateTime(InPara.PayDateTime),
                Pjh = InPara.OtherPara.Sjhm,
                Czgh = Config.YDJS_CZGH,
                Zfpb = 0
            };
            Ctx.BocJsjlSet.Add(bocJsjl);
            Ctx.SaveChanges();
        }

        /// <summary>
        /// 插入Hzyb_Jsjl表
        /// </summary>
        private void InsertHzybJsjl()
        {
            var ylrylb2 = GetYlrylb();
            var hzybJsjl = new HzybJsjl
            {
                Fphm = InPara.OtherPara.Fphm,
                Jzlx = InPara.OtherPara.Jzlx, //门诊2,住院3
                Yylsh = InPara.YbJsxx.YYJYLSH,
                Zxlsh = InPara.YbJsxx.ZXJYLSH,
                Jslsh = InPara.YbJsxx.JZLSH,
                Jsrq = DateTime.Now,
                Czgh = InPara.YbJsxx.Operator,
                Yllb = InPara.YbJsxx.YLLB,
                Rylb = ylrylb2,
                Yldy = InPara.YbJsxx.icinfo.fjrylb,
                Ywzq = InPara.YbJsxx.BusnissCycle,
                Ybkh = InPara.YbJsxx.icinfo.ybkh,
                Grbh = InPara.YbJsxx.icinfo.grbh,
                Qhdm = InPara.YbJsxx.icinfo.tcqydm,
                Yybh = InPara.YbJsxx.HospitalCode,
                Jzlsh = InPara.YbJsxx.JZLSH,
                Cqh = "1",
                Zjje = InPara.YbJsxx.ResultInfo.FeeTotal,
                Zfje = InPara.YbJsxx.ResultInfo.SelfPayTotal,
                Zlje = InPara.YbJsxx.ResultInfo.SelfDealTotal,
                Cxzf = InPara.YbJsxx.ResultInfo.CXJZF,
                Dnzh = InPara.YbJsxx.ResultInfo.DNZHJJ,
                Lnzf = InPara.YbJsxx.ResultInfo.LNZHJJ,
                Ybjj = InPara.YbJsxx.ResultInfo.YBJJZF,
                Xjje = InPara.YbJsxx.ResultInfo.PersonPay,
                Xjzf = InPara.YbJsxx.ResultInfo.PersonPay,
                Dnye = InPara.YbJsxx.ResultInfo.CurAccYE,
                Lnye = InPara.YbJsxx.ResultInfo.OldAccYE,
                Qflj = InPara.YbJsxx.ResultInfo.FirstPay,
                Yycdfy = InPara.YbJsxx.ResultInfo.YYCDFY,
                Zbjj = InPara.YbJsxx.ResultInfo.ZBJJ,
                Knjz = InPara.YbJsxx.ResultInfo.KNJZJJ,
                Sczl = InPara.YbJsxx.ResultInfo.SCJJZL,
                Sczf = InPara.YbJsxx.ResultInfo.SCJJZF,
                Lmjj = InPara.YbJsxx.ResultInfo.LMJJ,
                Bjjj = InPara.YbJsxx.ResultInfo.BJJJ,
                Tcjj = InPara.YbJsxx.ResultInfo.TCJJ,
                Lgrjj = InPara.YbJsxx.ResultInfo.LGRJJ,
                Qtjjzc = InPara.YbJsxx.ResultInfo.QTJJ,
                Zfpb = 0,
                Sybxbz = "0"
            };
            Ctx.HzybJsjlSet.Add(hzybJsjl);
            Ctx.SaveChanges();
        }

        /// <summary>
        /// 获取门诊结算相关表的关键字段
        /// </summary>
        private (int mzxh, int jlxh) GetOpIdentityKey()
        {
            var msIdentity = Ctx.MzIdentitySet
                .Find("MS_MZXX");
            var gyIdentity = Ctx.GyIdentitySet.Find("BOC_JSJL");
            if (msIdentity != null && gyIdentity != null)
            {
                var mzxh = msIdentity.Dqz + 1;
                msIdentity.Dqz = mzxh;

                var jlxh = gyIdentity.Dqz + 1;
                gyIdentity.Dqz = jlxh;

                Ctx.SaveChanges();
                return (mzxh, jlxh);
            }

            throw new Exception("获取MS_MZXX,BOC_JSJL序列号失败！");
        }

        /// <summary>
        /// 获取住院结算相关表的关键字段
        /// ZY_ZYJS，ZY_TBKK，BOC_JSJL
        /// </summary>
        private (int bocJlxh, int zyjsJlxh, int jkxh) GetInpIdentityKey()
        {
            int bocJlxh = 0, zyjsJlxh = 0, jkxh = 0;

            if (InPara.PayJsxx.Zfje > 0)
            {
                var zyIdentity = Ctx.ZyIdentitySet.Where(p => p.Bmc == "ZY_ZYJS" || p.Bmc == "ZY_TBKK").ToList();
                foreach (var item in zyIdentity)
                {
                    if (item != null)
                    {
                        if (item.Bmc == "ZY_ZYJS")
                        {
                            zyjsJlxh = item.Dqz + 1;
                            item.Dqz = zyjsJlxh;
                        }
                        else if (item.Bmc == "ZY_TBKK")
                        {
                            jkxh = item.Dqz + 1;
                            item.Dqz = jkxh;
                        }
                    }
                }
            }
            else
            {
                var zyIdentity = Ctx.ZyIdentitySet.Find("ZY_ZYJS");
                if (zyIdentity != null)
                {
                    if (zyIdentity.Bmc == "ZY_ZYJS")
                    {
                        zyjsJlxh = zyIdentity.Dqz + 1;
                        zyIdentity.Dqz = zyjsJlxh;
                    }
                }
            }

            var gyIdentity = Ctx.GyIdentitySet.Find("BOC_JSJL");
            if (gyIdentity != null)
            {
                bocJlxh = gyIdentity.Dqz + 1;
                gyIdentity.Dqz = bocJlxh;
            }

            if (bocJlxh < 0 || zyjsJlxh < 0 || jkxh < 0)
            {
                throw new Exception("获取ZY_ZYJS,BOC_JSJL,ZY_TBKK序列号失败！");
            }

            Ctx.SaveChanges();
            return (bocJlxh, zyjsJlxh, jkxh);
        }

        /// <summary>
        /// 根据传入人员类别转换为本地人员类别
        /// </summary>
        /// <returns></returns>
        private string GetYlrylb()
        {
            var originalRylb = InPara.YbJsxx.icinfo.ylrylb;
            var finalRylb = string.Empty;
            if ("1,2,3,4,5,6,7,8,9,10".IndexOf(originalRylb, StringComparison.Ordinal) < 0)
            {
                if ("31,32,33,34".IndexOf(originalRylb, StringComparison.Ordinal) >= 0)
                {
                    finalRylb = "3";
                }
                if ("35,36,37,38,39".IndexOf(originalRylb, StringComparison.Ordinal) >= 0)
                {
                    finalRylb = "6";
                }
                if (originalRylb == "61")
                {
                    finalRylb = "9";
                }
                if (originalRylb == "62")
                {
                    finalRylb = "10";
                }
                if ("31,32,33,34,35,36,37,38,39,61,62".IndexOf(originalRylb, StringComparison.Ordinal) < 0)
                {
                    finalRylb = originalRylb.Substring(0, 1);
                }
            }
            return finalRylb;
        }

        /// <summary>
        ///     HosPayConfirm入参数据校验
        /// </summary>
        private void ValidateHosPayConfirmIn()
        {
            var detailCount = InPara.fyqd.list.Count;
            if (detailCount < 1)
            {
                throw new Exception("/interface/fyqd/list/Detail节点没有数据，无法结算，请重试！");
            }

            if (string.IsNullOrEmpty(InPara.actnumber))
            {
                throw new Exception("获取actnumber失败！");
            }

            if (string.IsNullOrEmpty(InPara.PayLSH))
            {
                throw new Exception("获取结算流水号失败！");
            }

            if (string.IsNullOrEmpty(InPara.PayDateTime))
            {
                throw new Exception("获取结算日期失败！");
            }

            if (InPara.PayJsxx.Fyze != InPara.PayJsxx.Bxje + InPara.PayJsxx.Zfje)
            {
                throw new Exception("fyze金额与zfje+bxje不符，无法结算，请重试！！");
            }

            if (InPara.PayJsxx.Fyze != InPara.YbJsxx.ResultInfo.FeeTotal)
            {
                throw new Exception("PayJsxx.Fyze!=ybjsxx.ResultInfo.FeeTotal总额不等，不能结算");
            }

            if (InPara.PayJsxx.Bxje != InPara.YbJsxx.ResultInfo.YBJJZF + InPara.YbJsxx.ResultInfo.YYCDFY)
            {
                throw new Exception("PayJsxx_Bxje不等于ybjsxx_ResultInfo_YBJJZF与ybjsxx_ResultInfo_YYCDFY之和，不能结算");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.ZXJYLSH))
            {
                throw new Exception("InPara.YbJsxx.BusnissCycle数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.BusnissCycle))
            {
                throw new Exception("InPara.YbJsxx.BusnissCycle数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.JZLSH))
            {
                throw new Exception("InPara.YbJsxx.JZLSH数据不能为空");
            }

            if (InPara.YbJsxx.icinfo == null)
            {
                throw new Exception("InPara.YbJsxx.icinfo数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.YYJYLSH))
            {
                throw new Exception("InPara.YbJsxx.YYJYLSH数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.YLLB))
            {
                throw new Exception("InPara.YbJsxx.YLLB数据错误");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.DJH))
            {
                throw new Exception("InPara.YbJsxx.DJH数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.PayDate))
            {
                throw new Exception("InPara.YbJsxx.PayDate数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.icinfo.icxx))
            {
                throw new Exception("InPara.YbJsxx.icinfo.icxx数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.icinfo.grbh))
            {
                throw new Exception("InPara.YbJsxx.icinfo.grbh数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.icinfo.sfzh))
            {
                throw new Exception("InPara.YbJsxx.icinfo.sfzh数据不能为空");
            }

            if (string.IsNullOrEmpty(InPara.YbJsxx.icinfo.tcqydm))
            {
                throw new Exception("InPara.YbJsxx.icinfo.tcqydm数据不能为空");
            }
        }

        private string GetInpPayConfirm()
        {
            using (var transaction = Ctx.Database.BeginTransaction())
            {
                try
                {
                    var zyBrry = GetAndVerifyZyBrry(InPara.actnumber);

                    if (InPara.PayJsxx.yjje != zyBrry.ZyTbkks.Where(p => p.Zfpb == 0).Sum(p => p.Jkje))
                    {
                        throw new Exception("传入的yjje金额与实际jkje不符，无法结算，请重试！");
                    }

                    var medicare = GetMedicareType();
                    var identity = GetInpIdentityKey();
                    var sjhm = $"yd{identity.jkxh}";
                    var jsjk = zyBrry.ZyTbkks.FirstOrDefault(p => p.Jscs == 0)?.Sjhm;
                    if (string.IsNullOrEmpty(jsjk))
                    {
                        jsjk = sjhm;
                    }
                    else
                    {
                        jsjk = $"{jsjk},{sjhm}";
                    }

                    InPara.OtherPara = new OtherPayConfirmPara()
                    {
                        Brxz = medicare.brxz,
                        Ybpb = medicare.ybpb,
                        Jzlx = 3,
                        BocJsjl_Jlxh = identity.bocJlxh,
                        ZyJs_Jlxh = identity.zyjsJlxh,
                        Fphm = $"YD{identity.zyjsJlxh}",
                        ZyTbkk_Jkxh = identity.jkxh,
                        Sjhm = sjhm,
                        Jsjk = jsjk,
                        Jscs = (int)zyBrry.Jscs + 1
                    };
                    InsertZyTbkk(zyBrry);
                    InsertBocJsjl();
                    InsertZyZyjs(zyBrry);
                    UpdateZyTbkk(zyBrry);
                    UpdateZyFymx(zyBrry);
                    InsertZyJsmx(zyBrry);
                    UpdateZyCwsz(zyBrry.Zyh);
                    UpdateZyBrry(zyBrry);
                    //GetYlrylb();
                    InsertHzybJsjl();
                    var xml = GetInpResultXmlString(zyBrry.Zyh);
                    //throw new NotImplementedException();
                    transaction.Commit();
                    return xml;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw  new Exception("住院结算失败！"+e.Message);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="zyBrry"></param>
        private void UpdateZyBrry(ZyBrry zyBrry)
        {
            zyBrry.Jsrq = DateTime.Now;
            zyBrry.Jscs = InPara.OtherPara.Jscs;
            zyBrry.Cypb = 8;
            zyBrry.Xgpb = 0;
            Ctx.SaveChanges();
        }

        private void UpdateZyCwsz(int zyh)
        {
            var zyCwsz = Ctx.ZyCwszSet.Where(p => p.Zyh == zyh).ToList();
            if (zyCwsz.Any())
            {
                foreach (var item in zyCwsz)
                {
                    item.Zyh = null;
                }

                Ctx.SaveChanges();
            }
        }

        private void UpdateZyTbkk(ZyBrry zyBrry)
        {
            var zyTbkk = zyBrry.ZyTbkks.Where(p => p.Jscs == 0);
            foreach (var item in zyTbkk)
            {
                item.Jscs = InPara.OtherPara.Jscs;
            }
            Ctx.SaveChanges();
        }

        private void UpdateZyFymx(ZyBrry zyBrry)
        {
            var zyFymx = zyBrry.ZyFymxs.Where(p => p.Jscs == 0);
            foreach (var item in zyFymx)
            {
                item.Jscs = InPara.OtherPara.Jscs;
            }

            Ctx.SaveChanges();
        }

        private void InsertZyJsmx(ZyBrry zyBrry)
        {
            var query = zyBrry.ZyFymxs.GroupBy(p => new { p.Zyh, p.Jscs, p.Fyks, p.Fyxm, p })
                .Select(t => new
                {
                    t.Key,
                    Zjje = t.Sum(p => p.Zjje),
                    Zfje = t.Sum(p => p.Zfje),
                    Zlje = t.Sum(p => p.Zlje)
                }).ToList();

            if (query.Any())
            {
                foreach (var item in query)
                {
                    var zyJsmx = new ZyJsmx()
                    {
                        Zyh = zyBrry.Zyh,
                        Jscs = item.Key.Jscs,
                        Ksdm = item.Key.Fyks,
                        Fyxm = item.Key.Fyxm,
                        Zjje = item.Zjje,
                        Zfje = item.Zfje,
                        Zlje = item.Zlje
                    };
                    Ctx.ZyJsmxSet.Add(zyJsmx);
                }
            }
            Ctx.SaveChanges();
        }

        private void InsertZyTbkk(ZyBrry zyBrry)
        {
            var zyTbkk = new ZyTbkk()
            {
                Jkxh = InPara.OtherPara.ZyTbkk_Jkxh,
                Zyh = zyBrry.Zyh,
                Jkrq = DateTime.Now,
                Jkje = InPara.PayJsxx.Zfje,
                Jkfs = 3,
                Sjhm = InPara.OtherPara.Sjhm,
                Jscs = (int)zyBrry.Jscs + 1,
                Czgh = Config.YDJS_CZGH,
                Zfpb = 0
            };
            Ctx.ZyTbkkSet.Add(zyTbkk);
            Ctx.SaveChanges();
        }

        private void InsertZyZyjs(ZyBrry zyBrry)
        {
            var fyhj = zyBrry.ZyFymxs.Where(p => p.Jscs == 0).Sum(p => p.Zjje);
            var yef = zyBrry.ZyFymxs.Where(p => p.Jscs == 0 && p.Yefbz == 1).Sum(p => p.Zjje);
            var zyZyjs = new ZyZyjs()
            {
                Zyh = zyBrry.Zyh,
                Jscs = InPara.OtherPara.Jscs,
                Jslx = 5,
                Ksrq = zyBrry.Ryrq,
                Zzrq = zyBrry.Cyrq,
                Jsrq = DateTime.Now,
                Fyhj = fyhj,
                Zfhj = fyhj - InPara.PayJsxx.Bxje,
                Jkhj = InPara.PayJsxx.yjje + InPara.PayJsxx.Zfje,
                Xjje = 0,
                Fphm = InPara.OtherPara.Fphm,
                Czgh = Config.YDJS_CZGH,
                Zfpb = 0,
                Qtje = 0,
                Qtfs = null,
                Jsjk = InPara.OtherPara.Jsjk,
                Srje = 0,
                Brxz = zyBrry.Brxz,
                Jrzf = 0,
                Cjbz = 0,
                Yef = yef,
                Jkda = 0,
                Jmje = 0,
                Paylsh = InPara.PayLSH,
                Dzpj = InPara.ElectronicInvoiceNumber,
                Jsjkxh = InPara.OtherPara.ZyTbkk_Jkxh
            };
            Ctx.ZyZyjsSet.Add(zyZyjs);
            Ctx.SaveChanges();
        }

        /// <summary>
        ///     验证住院病人是否可以结算
        /// </summary>
        /// <param name="actNumber">唯一代码</param>
        /// <returns></returns>
        private ZyBrry GetAndVerifyZyBrry(string actNumber)
        {
            var patient = Ctx.ZyBrrySet.Where(p => p.Actnumber == actNumber)
                .Include(p => p.ZyTbkks)
                .Include(p => p.ZyFymxs)
                .FirstOrDefault();
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

        /// <summary>
        /// 判断病人是否为医保结算
        /// </summary>
        /// <returns></returns>
        private (int ybpb, int brxz) GetMedicareType()
        {
            if (InPara.YbJsxx.CVX_CardType == "02")
            {
                return (1, 4000);
            }

            return (0, 1000);
        }
    }
}
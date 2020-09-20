using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Xml.Linq;
using FrontEndModel;
using Newtonsoft.Json;
namespace FrontEndRequestHandle
{
    public class ExecuteProcedureFactory
    {
        private readonly FrontEndContext _ctx;
        public ExecuteProcedureFactory()
        {
            _ctx = new FrontEndContext();
        }
        /// <summary>
        /// 获取某个科室所有医生排班状态
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetKsYsPb(string inXml)
        {
            XElement root = null;
            try
            {
                var xml = XElement.Parse(inXml);
                var ksdm = xml.Element("ksdm")?.Value;
                var ksrq = Convert.ToDateTime(xml.Element("ksrq")?.Value);
                var zzrq = Convert.ToDateTime(xml.Element("zzrq")?.Value);
                var list = getKsyspb(ksdm, ksrq, zzrq);
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
            }
            catch (Exception e)
            {
                throw e;
            }
            return root.ToString();
        }
        private IList<ksyspb> getKsyspb(string ksdm, DateTime kssj, DateTime jssj)
        {
            try
            {
               return _ctx.Database.SqlQuery<ksyspb>($"exec proc_wjj_yspb '{ksdm}','{kssj}','{jssj}'").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("获取科室所有医生排班信息失败0"+e.Message); ;
            }
        }
        /// <summary>
        ///     门诊分时段预约号源
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetMzFsdYy(string inXml)
        {
            string rtnXml;
            try
            {
                var xml = XElement.Parse(inXml);
                var ksdm = xml.Element("ksdm")?.Value;
                var ysdm = xml.Element("ysdm")?.Value;
                var gzrq = Convert.ToDateTime(xml.Element("gzrq")?.Value);
                var zblb = Convert.ToInt32(xml.Element("zblb")?.Value);
                var yypb = _ctx.MzFsdYySet.Where(p =>
                        p.gzrq == gzrq &&
                        p.ksdm == ksdm &&
                        p.ysdm == ysdm &&
                        p.zblb == zblb &&
                        p.yylb == 1 &&
                        p.ghpb == 0)
                    .ToList();
                if (yypb.Any())
                {
                    var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("YyghInterface",
                            new XElement("RtnValue", 1),
                            new XElement("bzxx", ""),
                            new XElement("interface")
                        ));
                    //var interfaceNode = xmlElement.Element("interface");
                    foreach (var item in yypb)
                    {
                        document.Root?.Element("interface")
                            ?.Add(new XElement("row",
                                new XElement("jzxh", item.jzxh),
                                new XElement("jzsj", item.jzsj),
                                new XElement("jzsj2", item.jzsj.AddMinutes(30))
                            ));
                    }
                    rtnXml = document.ToString();
                }
                else
                {
                    rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
                }
            }
            catch (Exception e)
            {
                rtnXml = GeneralTools.ReturnXml(-1, "数据查询出现错误！~r~n" + e, null);
            }
            return rtnXml.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
        }
        /// <summary>
        ///     使用Linq方式获取科室排班信息
        /// </summary>
        /// <returns></returns>
        private IList<WsjGhks> GetGhkses2() =>
            (from a in _ctx.MzGhksSet
             where a.kfyypb == 1 && a.zfpb == 0
             join b in from e in _ctx.PayDmzdSet where e.dmlb == "GHKS_DZ" select e
                 on a.ksdm equals b.dmsb into aJoin
             from t in aJoin.DefaultIfEmpty()
             join c in from x in _ctx.GyDmzdSet where x.dmlb == 1165 select x
                 on a.kswz equals c.dmsb into cJoin
             from d in cJoin.DefaultIfEmpty()
             select new WsjGhks
             {
                 bzdm = t.dmbz,
                 ksdm = a.ksdm,
                 ksmc = a.ksmc,
                 zjpb = a.ghlb == 3 ? 1 : 0,
                 ghje = a.ghf + a.zlf,
                 zswz = d.dmmc,
                 bzxx = a.zjsjap
             }).ToList();
        public string GetMzGhksXml2(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = GetGhkses2();
            if (query.Any())
            {
                var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", ""),
                        new XElement("interface")
                    ));
                foreach (var item in query)
                {
                    document.Root?.Element("interface")?.Add(item.ToXml());
                }
                rtnXml = document.ToString();
            }
            else
            {
                rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }
            return rtnXml;
        }
        public string GetMzGhksXml(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = _ctx.Database.SqlQuery<WsjGhks>("exec proc_get_ghks").Where(p => p.kfyypb == mode).ToList();
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
        public string GetPatientInvoice(string inXml)
        {
            try
            {
                var path = $@"{AppContext.BaseDirectory}\appconfig.json";
                //var jsonConfig = GeneralTools.GetJObjectFromFile(path);
                var gc = JsonConvert.DeserializeObject<GenericConfig>(File.ReadAllText(path));
                var xml = XElement.Parse(inXml);
                var actType = xml.Element("acttype")?.Value;
                var actNumber = xml.Element("actnumber")?.Value;
                if (string.IsNullOrEmpty(actNumber)) throw new Exception("获取actnumber参数失败!");
                gc.ActNumber = actNumber;
                //var jzlsh = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "jzlsh")?.Value;
                //var mzzyhm = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "mzzyhm")?.Value;
                if (string.IsNullOrEmpty(gc.YYBH)) throw new Exception("获取医院编码失败");
                if (string.IsNullOrEmpty(gc.CZGH)) throw new Exception("获取操作工号失败");
                if (actType == "4")
                {
                    return GetInpatientInvoices(gc);
                }
                return GetOutpatientInvoices(gc);
            }
            catch (Exception exception)
            {
                return new XElement("YyghInterface",
                    new XElement("RtnValue", -1),
                    new XElement("bzxx", exception.Message)
                ).ToString();
            }
        }
        /// <summary>
        ///     住院病人费用清单
        /// </summary>
        /// <returns></returns>
        public string GetInpatientInvoices(GenericConfig gc)
        {
            var xml = new XElement("YyghInterface");
            try
            {
                var patient = VerifyInpatient(gc.ActNumber);
                var cvxCardType = GetCvxCardType(gc.HZYB_BRXZ, gc.WXYB_BRXZ, patient.BRXZ.ToString());
                if (cvxCardType != "08")
                {
                    var noUpload = _ctx.zy_fymx.Any(p => p.zyh == patient.ZYH && p.scbz == 0 && p.jscs == 0);
                    if (noUpload) throw new Exception("本次住院结算有未上传的明细记录");
                }
                var fee = GetInpatientFee(patient.ZYH, (int)(patient.yepb ?? 0));
                //预交款
                var yjk = _ctx.zy_tbkk.Where(p => p.zyh == patient.ZYH && p.zfpb == 0 && p.jscs == 0)
                    ?.Select(p => p.jkje).DefaultIfEmpty(0).Sum();
                var clinic = GetInpatientClinicInfo(patient.ZYH, fee.cnt1);
                var feeSummary = GetInpatientFeeSummary(patient.ZYH);
                xml.Add(
                    new XElement("RtnValue", 1),
                    new XElement("bzxx", "获取出院费用清单成功"),
                    new XElement("interface",
                        new XElement("HospitalCode", gc.YYBH),
                        new XElement("Operator", gc.CZGH),
                        new XElement("CVX_CardType", cvxCardType),
                        new XElement("ICInfo", patient.cardno),
                        new XElement("ChargeType", 4),
                        new XElement("YLLB", patient.yllb), //门诊的医疗类别为11，固定值
                        new XElement("DisAudNo"),
                        new XElement("FeeTotal", fee.zjje2 + fee.zjje1),
                        new XElement("ZFFY", fee.zjje2),
                        new XElement("yjje", yjk),
                        new XElement("DisMark", 0),
                        new XElement("OperatorName"),
                        clinic.ToXml(),
                        new XElement("zyfymx")
                    )
                );
                var listNode = xml.Descendants("interface").Elements("zyfymx").FirstOrDefault();
                foreach (var item in feeSummary)
                {
                    var arr = item.Split('-');
                    listNode?.Add(new XElement($"I{arr[0]}", arr[1]));
                }
            }
            catch (Exception e)
            {
                throw e;
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
            var patient = _ctx.ZyBrrySet.FirstOrDefault(p => p.actnumber == actNumber);
            if (patient == null) throw new Exception("获取住院病人档案失败");
            if (patient.CYPB == 0) throw new Exception("未完成出院证明操作");
            if (patient.CYPB == 8) throw new Exception("已完成出院结算");
            if (patient.CYPB == 99) throw new Exception("本次住院已注销");
            if (patient.XGPB == 2) throw new Exception("正在进行费别转换2");
            if (patient.XGPB == 9) throw new Exception("正在进行出院结算9");
            if (patient.YDJSBZ == 0) throw new Exception("该就诊信息移动结算检测未通过");
            return patient;
        }
        private (int cnt1, int cnt2, decimal zjje1, decimal zjje2) GetInpatientFee(int zyh, int yepb)
        {
            int cnt1;
            var cnt2 = 0;
            decimal zjje1;
            decimal zjje2 = 0;
            var mx = _ctx.zy_fymx
                .Where(p => p.jscs == 0 && p.zyh == zyh)
                .GroupBy(p => p.yefbz).Select(t => new
                {
                    yefbz = t.Key,
                    zjje = t.Sum(p => p.zjje),
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
            if (cnt2 + cnt1 == 0) throw new Exception("本次住院结算无费用明细数据");
            return (cnt1, cnt2, zjje1, zjje2);
        }
        private Clinic GetInpatientClinicInfo(int zyh, int count)
        {
            var clinic = _ctx.Database.SqlQuery<Clinic>($"exec proc_wjj_inclinic {zyh}").FirstOrDefault();
            if (clinic == null) throw new Exception("获取住院相关信息失败");
            //获取诊断
            clinic.CYZD = GetInpatientClinicDiagnose(zyh);
            clinic.FeeDetail = count;
            return clinic;
        }
        /// <summary>
        ///     获取住院病人临床诊断
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private IList<string> GetInpatientClinicDiagnose(int zyh)
        {
            var sql = $@"SELECT
                              gj.ICD9 AS ICD9
                            FROM zy_ryzd zr
                                ,gy_jbbm gj
                            WHERE zr.ZDXH = gj.jbxh
                            AND zr.ZYH = {zyh}
                            AND zr.zdlb IN (3, 4)";
            var query = _ctx.Database.SqlQuery<string>(sql).ToList();
            if (!query.Any()) throw new Exception("出入院诊断获取失败！");
            return query;
        }
        /// <summary>
        /// 获取住院费用分类信息
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <returns></returns>
        private IList<string> GetInpatientFeeSummary(int zyh)
        {
            var sql = $@"select (ISNULL(gs.zxgb, '99'))+'-'+ CAST(SUM(zf.zjje) AS VARCHAR)
                            FROM zy_fymx zf,gy_sfxm gs
                            WHERE zf.fyxm = gs.sfxm
                            AND zf.zyh = {zyh}
                            AND zf.jscs =0
                            GROUP BY gs.zxgb";
            var query = _ctx.Database.SqlQuery<string>(sql).ToList();
            if (!query.Any()) throw new Exception("费用分类数据获取失败！");
            return query;
        }
        /// <summary>
        /// 拼接门诊病人费用字符串
        /// </summary>
        /// <returns></returns>
        public string GetOutpatientInvoices(GenericConfig gc)
        {
            var xml = new XElement("YyghInterface");
            try
            {
                //获取病人信息
                var jzls = _ctx.ys_mz_jzls.FirstOrDefault(p => p.actnumber == gc.ActNumber);
                if (jzls == null) throw new Exception("获取门诊就诊记录失败");
                if (jzls.brbh <= 0) throw new Exception("获取门诊病人档案失败");
                var patient = _ctx.MzBrdaSet.Find(jzls.brbh);
                if (patient == null || patient.brxz <= 0) throw new Exception("获取病人基本信息失败");
                var clinic = _ctx.Database.SqlQuery<Clinic>($"exec proc_wjj_outclinic {jzls.jzxh}").FirstOrDefault();
                if (clinic == null) throw new Exception("获取门诊clinic信息失败");
                //获取费用清单
                var details = GetOutpatientFeeDetails((int)patient.brid, gc, (int)(patient.qybr ?? 0));
                clinic.FeeDetail = details.Select(p => p.Items.Count).DefaultIfEmpty(0).Sum();
                //组装xml语句
                xml.Add(
                    new XElement("RtnValue", 1),
                    new XElement("bzxx", "获取门诊费用清单成功"),
                    new XElement("interface",
                        new XElement("HospitalCode", gc.YYBH),
                        new XElement("Operator", gc.CZGH),
                        new XElement("CVX_CardType",
                            GetCvxCardType(gc.HZYB_BRXZ, gc.WXYB_BRXZ, patient.brxz.ToString())),
                        new XElement("ICInfo", GetIcInfor(patient.ickh, patient.ybkh, patient.icxx)),
                        new XElement("ChargeType", 1),
                        new XElement("YLLB", 11), //门诊的医疗类别为11，固定值
                        new XElement("DisAudNo"),
                        new XElement("FeeTotal", details.Sum(p => p.itemCost)),
                        new XElement("ZFFY", 0),
                        new XElement("yjje", 0),
                        new XElement("DisMark", 0),
                        new XElement("OperatorName"),
                        clinic.ToXml(),
                        GetOutpatientFeeXml(details)
                    )
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return xml.ToString();
        }
        /// <summary>
        /// 获取门诊费用明细XML
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        private XElement GetOutpatientFeeXml(IList<Detail> details)
        {
            var xml = new XElement("list");
            foreach (var detail in details)
            {
                xml.Add(detail.ToXml());
            }
            return xml;
        }
        /// <summary>
        ///     获取门诊费用详单
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="gc"></param>
        /// <param name="qybr"></param>
        /// <returns></returns>
        private IList<Detail> GetOutpatientFeeDetails(int brid, GenericConfig gc, int qybr)
        {
            var cfsj = DateTime.Now.AddDays(0 - gc.CFXQ);
            var webCfsj = DateTime.Now.AddDays(0 - gc.WebCFXQ);
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
            var list = _ctx.Database.SqlQuery<Detail>(sql).ToList();
            if (list.Any())
            {
                try
                {
                    foreach (var item in list)
                    {
                        if (item.Type == 1)
                        {
                            item.Items = _ctx.Database.SqlQuery<item>($"exec proc_wjj_cfmx {item.itemNo}").ToList();
                        }
                        else
                        {
                            item.Items = _ctx.Database.SqlQuery<item>($"exec proc_wjj_yjmx {item.itemNo}").ToList();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("获取处方或检查明细失败");
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
        /// <param name="hzBrxz">杭州医保病人性质</param>
        /// <param name="wxBrxz">原网新医保病人性质</param>
        /// <param name="brxz">病人性质</param>
        /// <returns></returns>
        public string GetCvxCardType(string hzBrxz, string wxBrxz, string brxz)
        {
            if (hzBrxz == brxz || wxBrxz == brxz)
            {
                return "02";
            }
            return "08";
        }
        /// <summary>
        ///     返回医保ic卡信息
        /// </summary>
        /// <param name="ickh"></param>
        /// <param name="ybkh"></param>
        /// <param name="icxx"></param>
        /// <returns></returns>
        public string GetIcInfor(string ickh, string ybkh, string icxx)
        {
            if (string.IsNullOrEmpty(ickh)) ickh = "";
            if (string.IsNullOrEmpty(ybkh)) ybkh = "";
            if (string.IsNullOrEmpty(icxx)) icxx = "";
            if (ickh.Length <= 30)
            {
                if (ybkh.Length >= 30)
                {
                    return ybkh;
                }
                if (icxx.Length > 100) return icxx.Trim().Substring(0, 50).Trim();
            }
            return ickh;
        }
        public string GetCodePayXml(string inXmlStr)
        {
            string yyjsls = string.Empty;
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
                        jydm = "hos_codepay",
                        jylx = "1",
                        yyjsls = yyjsls,
                        xrrq = DateTime.Now,
                        instr = inXmlStr
                    };
                    _ctx.PayFkrzSet.Add(fkrz);
                    _ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("业务日志保存失败/r/n" + e.Message);
                }
                var record = _ctx.PayFkjlSet.Find(yyjsls);
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
                        jydm = "hos_codepay",
                        jylx = "2",
                        yyjsls = yyjsls,
                        xrrq = DateTime.Now,
                        instr = outXml
                    };
                    _ctx.PayFkrzSet.Add(fkrz);
                    _ctx.SaveChanges();
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
                    _ctx.SaveChanges();
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
                    jydm = "hos_codepay",
                    jylx = "2",
                    yyjsls = yyjsls,
                    xrrq = DateTime.Now,
                    instr = outXml
                };
                _ctx.PayFkrzSet.Add(fkrz);
                _ctx.SaveChanges();
                return outXml;
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
    }
}
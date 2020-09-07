using FrontEndModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        /// 门诊分时段预约号源
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetMzFsdYy(string inXml)
        {
            string rtnXml;
            try
            {
                XElement xml = XElement.Parse(inXml);
                string ksdm = xml.Element("ksdm")?.Value;
                string ysdm = xml.Element("ysdm")?.Value;
                DateTime gzrq = Convert.ToDateTime(xml.Element("gzrq")?.Value);
                int zblb = Convert.ToInt32(xml.Element("zblb")?.Value);
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
                    XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
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
                    rtnXml = XmlHandle.ReturnXml(-1, "没有查询到数据！~r~n", null);
                }
            }
            catch (Exception e)
            {
                rtnXml = XmlHandle.ReturnXml(-1, "数据查询出现错误！~r~n" + e, null);
            }
            return rtnXml.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");

        }
        /// <summary>
        /// 使用Linq方式获取科室排班信息
        /// </summary>
        /// <returns></returns>
        private IList<WsjGhks> GetGhkses2()
        {
            return (from a in _ctx.MzGhksSet
                    where a.kfyypb == 1 && a.zfpb == 0
                    join b in (from e in _ctx.PayDmzdSet where e.dmlb == "GHKS_DZ" select e)
                        on a.ksdm equals b.dmsb into aJoin
                    from t in aJoin.DefaultIfEmpty()
                    join c in (from x in _ctx.GyDmzdSet where x.dmlb == 1165 select x)
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
        }

        public string GetMzGhksXml2(string inXml)
        {
            XElement xml = XElement.Parse(inXml);
            int mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = GetGhkses2();
            if (query.Any())
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
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
                rtnXml = XmlHandle.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }

            return rtnXml;
        }
        public string GetMzGhksXml(string inXml)
        {
            XElement xml = XElement.Parse(inXml);
            int mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = _ctx.Database.SqlQuery<WsjGhks>("exec proc_get_ghks").Where(p=>p.kfyypb==mode).ToList();
            if (query.Any())
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", ""),
                        new XElement("interface")
                 ));

                query.ForEach(p =>
                {
                    document.Root?.Element("interface")?.Add(p.ToXml());
                });
                rtnXml = document.ToString();
            }
            else
            {
                rtnXml = XmlHandle.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }

            return rtnXml;
        }
    }

    public class WsjGhks
    {
        public string bzdm { get; set; }
        public string ksdm { get; set; }
        public string ksmc { get; set; }
        public int zjpb { get; set; }
        public decimal ghje { get; set; }
        public string zswz { get; set; }
        public string bzxx { get; set; }
        public virtual decimal kfyypb { get; set; }

        public XElement ToXml()
        {
            var info = typeof(WsjGhks);
            var properties = info.GetProperties();
            var xml = new XElement("row");
            foreach (var property in properties)
            {
                //如果有IsVirtual跳过
                if (property.GetAccessors().Any(p=>p.IsVirtual)) continue;
                xml.Add(new XElement(property.Name, property.GetValue(this)));
            }
            return xml;
        }
    }


}

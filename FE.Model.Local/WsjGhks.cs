using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FE.Model.Local
{
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
            var info = this.GetType();
            var properties = info.GetProperties();
            var xml = new XElement("row");
            foreach (var property in properties)
            {
                //如果有IsVirtual跳过
                if (property.GetAccessors().Any(p => p.IsVirtual)) continue;
                xml.Add(new XElement(property.Name, property.GetValue(this)));
            }
            return xml;
        }
    }
}

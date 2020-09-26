using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FE.Model.Local
{
    public class Clinic
    {
        public string ClinicNo { get; set; }

        /// <remarks/>
        public DateTime ClinicDate { get; set; }

        /// <remarks/>
        public string DeptCode { get; set; }

        /// <remarks/>
        public string DeptGBCode { get; set; }

        /// <remarks/>
        public string DeptName { get; set; }

        /// <remarks/>
        public string DocName { get; set; }

        /// <remarks/>
        public string DocSfzh { get; set; }

        /// <remarks/>
        public string DisCode { get; set; }

        /// <remarks/>
        public string DisName { get; set; }

        /// <remarks/>
        public string DisDesc { get; set; }

        public virtual IList<string> CYZD { get; set; }

        public int FeeDetail { get; set; }
        public XElement ToXml()
        {
            var info = this.GetType();
            var properties = info.GetProperties();
            var xml = new XElement(this.GetType().Name);
            foreach (var property in properties)
            {
                //如果有IsVirtual跳过
                if (property.GetAccessors().Any(p => p.IsVirtual)) continue;
                xml.Add(new XElement(property.Name, property.GetValue(this)));
            }

            var cyzd = new XElement("CYZD");
            if (CYZD == null)
            {
                cyzd.Add(new XElement("Item", DisCode));
            }
            else
            {
                foreach (var item in CYZD)
                {
                    cyzd.Add(new XElement("Item", item));
                }
            }
            xml.Add(cyzd);
            return xml;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FrontEndModel
{
    public class Detail
    {
        /// <remarks/>
        public int Type { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public int ItemNo { get; set; }

        /// <remarks/>
        public decimal ItemCost { get { return Items.Sum(p => p.ItemTotal); } }

        /// <remarks/>
        public virtual List<Item> Items { get; set; }

        public XElement ToXml()
        {
            var className = this.GetType().Name;
            var info = this.GetType();
            var properties = info.GetProperties();
            var xml = new XElement(className);
            foreach (var property in properties)
            {
                //如果有IsVirtual跳过
                if (property.GetAccessors().Any(p => p.IsVirtual)) continue;
                xml.Add(new XElement(property.Name, property.GetValue(this)));
            }
            foreach (var item in Items)
            {
                xml.Add(item.ToXml());
            }

            return xml;
        }
    }

    public class Item
    {
        public decimal ItemNumber { get; set; }

        /// <remarks/>
        public int XMLB { get; set; }

        /// <remarks/>
        public string SFLB { get; set; }

        /// <remarks/>
        public int DetailType { get; set; }

        /// <remarks/>
        public string ItemCode { get; set; }

        /// <remarks/>
        public string ItemHospCode { get; set; }

        /// <remarks/>
        public string ItemHospName { get; set; }

        /// <remarks/>
        public int SDFlag { get; set; }

        /// <remarks/>
        public decimal Price { get; set; }

        /// <remarks/>
        public decimal Amount { get; set; }

        /// <remarks/>
        public decimal Amount_T { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string Spec { get; set; }

        /// <remarks/>
        public string MedType { get; set; }

        /// <remarks/>
        public decimal ItemTotal { get; set; }

        /// <remarks/>
        public int SelfDeal { get; set; }

        /// <remarks/>
        public int SelfPay { get; set; }

        /// <remarks/>
        public string DayTimes { get; set; }

        /// <remarks/>
        public decimal Dosage { get; set; }

        /// <remarks/>
        public decimal SelfPayRate { get; set; }

        /// <remarks/>
        public int QEZFBZ { get; set; }

        /// <remarks/>
        public string DisAudNo_DJ { get; set; }

        /// <remarks/>
        public string Usage { get; set; }

        public XElement ToXml()
        {
            var className = this.GetType().Name;
            var info = this.GetType();
            var properties = info.GetProperties();
            var xml = new XElement(className);
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
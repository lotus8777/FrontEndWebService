using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Local
{


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class HosInvoiceIn
    {
        /// <remarks/>
        public string actnumber { get; set; }

        /// <remarks/>
        public string fphm { get; set; }
    }





    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public class HosInvoiceOut
    {
        /// <remarks/>
        public int RtnValue { get; set; } = 1;

        /// <remarks/>
        public string bzxx { get; set; } = "发票明细查询成功";

        /// <remarks/>
        [XmlArrayItem("item", IsNullable = false)]
        public List<InvoiceItem> sfxmmx { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InvoiceItem
    {
        /// <remarks/>
        public decimal item_no { get; set; }

        /// <remarks/>
        public string item_class { get; set; }

        /// <remarks/>
        public decimal item_code { get; set; }

        /// <remarks/>
        public string item_name { get; set; }

        /// <remarks/>
        public string item_spec { get; set; }

        /// <remarks/>
        public string units { get; set; }

        /// <remarks/>
        public decimal ammount { get; set; }

        /// <remarks/>
        public decimal unitprice { get; set; }

        /// <remarks/>
        public decimal price { get; set; }

        /// <remarks/>
        public string zxksbm { get; set; }

        /// <remarks/>
        public string zxksmc { get; set; }

        /// <remarks/>
        public decimal zfbl { get; set; }
    }


}

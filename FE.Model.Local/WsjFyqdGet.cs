using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FE.Model.Local
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public class WsjFyqdGetIn
    {
        /// <remarks/>
        public string actnumber { get; set; }

        /// <remarks/>
        public int zzjgdm { get; set; }
        /// <remarks/>
        public string kssj { get; set; }
        [XmlIgnore]
        public DateTime start => Convert.ToDateTime(kssj);

        /// <remarks/>
        public string  jssj { get; set; }
        [XmlIgnore]
        public DateTime stop => Convert.ToDateTime(jssj);

        /// <remarks/>
        public string mode { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName= "YyghInterface")]
    public partial class WsjFyqdGetOut
    {
        /// <remarks/>
        public byte RtnValue { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }

        [XmlElement("interface")]
        public WsjFyqdGetInterface FyqdGetInterface { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    //[XmlRoot("interface")]
    public partial class WsjFyqdGetInterface
    {
        /// <remarks/>
        public YyghInterfaceInterfaceJbxx jbxx { get; set; }

        /// <remarks/>
        [XmlArrayItem("item", IsNullable = false)]
        public YyghInterfaceInterfaceItem[] fyqd { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class YyghInterfaceInterfaceJbxx
    {
        /// <remarks/>
        public string brxm { get; set; }

        /// <remarks/>
        public string fyxz { get; set; }

        /// <remarks/>
        public DateTime ryrq { get; set; }

        /// <remarks/>
        public DateTime cyrq { get; set; }

        /// <remarks/>
        public int zyts { get; set; }

        /// <remarks/>
        public string brch { get; set; }

        /// <remarks/>
        public string zyhm { get; set; }

        /// <remarks/>
        public string ksmc { get; set; }

        /// <remarks/>
        public decimal fyze { get; set; }

        /// <remarks/>
        public decimal fyxj { get; set; }

        /// <remarks/>
        public decimal zfhj { get => fyxj; }

        /// <remarks/>
        public decimal yjk { get; set; }
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class YyghInterfaceInterfaceItem
    {
        /// <remarks/>
        public decimal fylxdm { get; set; }

        /// <remarks/>
        public string fylxmc { get; set; }

        /// <remarks/>
        public decimal xmxj { get; set; }

        /// <remarks/>
        public decimal zfxj { get; set; }

        /// <remarks/>
        [XmlArrayItem("fyitem")]
        public YyghInterfaceInterfaceItemFyitem[] fyitem { get; set; }
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class YyghInterfaceInterfaceItemFyitem
    {
        /// <remarks/>
        public decimal fydm { get; set; }

        /// <remarks/>
        public string fymc { get; set; }

        /// <remarks/>
        public decimal fydj { get; set; }

        /// <remarks/>
        public decimal fysl { get; set; }

        /// <remarks/>
        public decimal fyje { get; set; }

        /// <remarks/>
        public decimal yblb { get; set; }

        /// <remarks/>
        public decimal zfje { get; set; }
    }



}
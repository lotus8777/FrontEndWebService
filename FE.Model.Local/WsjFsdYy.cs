using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FE.Model.Local
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class WsjFsdYyIn
    {
        /// <remarks/>
        public string ksdm { get; set; }

        /// <remarks/>
        public string ysdm { get; set; }

        /// <remarks/>
        public string gzrq { get; set; }

        /// <remarks/>
        public byte zblb { get; set; }

        /// <remarks/>
        public byte ghlb { get; set; }

        /// <remarks/>
        public byte zjpb { get; set; }

        /// <remarks/>
        public uint zzjgdm { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "YyghInterface")]
    public class WsjFsdYyOut
    {
        /// <remarks/>
        public byte RtnValue { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }

        //[XmlElement("interface")]
        [XmlArrayItem("row", IsNullable = false)]
        public List<FsdYyRow> FsdYyRows { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class FsdYyRow
    {
        /// <remarks/>
        public decimal jzxh { get; set; }

        /// <remarks/>
        public DateTime jzsj { get; set; }

        /// <remarks/>
        public DateTime jzsj2 { get; set; }
    }


}

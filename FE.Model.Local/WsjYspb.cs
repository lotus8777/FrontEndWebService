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
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public class WsjYspbIn
    {
        /// <remarks/>
        public string zzjgdm { get; set; }

        /// <remarks/>
        public string ksdm { get; set; }

        /// <remarks/>
        public string ksrq { get; set; }

        /// <remarks/>
        public string zzrq { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "YyghInterface")]
    public class WsjYspbOut
    {
        /// <remarks/>
        public int RtnValue { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }

        /// <remarks/>
        [XmlArrayItem("row", IsNullable = false)]
        public  List<YspbRow> YspbRows { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class YspbRow
    {
        /// <remarks/>
        public DateTime gzrq { get; set; }

        /// <remarks/>
        public  decimal  zblb { get; set; }

        /// <remarks/>
        public  string  ysdm { get; set; }

        /// <remarks/>
        public string ysxm { get; set; }

        /// <remarks/>
        public string djyssfzh { get; set; }

        /// <remarks/>
        public  decimal  ghxe { get; set; }

        /// <remarks/>
        public  int  zjpb { get; set; }

        /// <remarks/>
        public  int  ghlb { get; set; }

        /// <remarks/>
        public decimal ghje { get; set; }

        /// <remarks/>
        public  int  pbzt { get; set; }
    }


}

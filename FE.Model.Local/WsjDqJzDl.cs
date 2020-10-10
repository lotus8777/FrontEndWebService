using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FE.Model.Local
{
    //WsjDqJzDlIn

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    //[Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class WsjDqJzDlIn
    {
        /// <remarks/>
        public string ksdm { get; set; }

        /// <remarks/>
        public string ghks { get; set; }

        /// <remarks/>
        public string ysdm { get; set; }

        /// <remarks/>
        public string gzrq { get; set; }

        /// <remarks/>
        public int zblb { get; set; }

        /// <remarks/>
        public byte ghlb { get; set; }

        /// <remarks/>
        public string zzjgdm { get; set; }
    }



    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    //[Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "YyghInterface")]
    public class WsjDqJzDlOut
    {
        /// <remarks/>
        public byte RtnValue { get; set; }

        /// <remarks/>
        public object bzxx { get; set; }

        /// <remarks/>
        public DqJzCx Jzcx { get; set; }
    }

    /// <remarks/>
    //[Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DqJzCx
    {
        /// <remarks/>
        public decimal dqcx { get; set; }
    }



}

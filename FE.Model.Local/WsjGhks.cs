﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FE.Model.Local
{


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class WsjGhksIn
    {
        /// <remarks/>
        public string zzjgdm { get; set; }

        /// <remarks/>
        public decimal mode { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "YyghInterface")]
    public class WsjGhksOut
    {
        /// <remarks/>
        public int RtnValue { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }

        /// <remarks/>
        [XmlArrayItem("row", IsNullable = false)]
        public List<GhksRow> GhksRows { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GhksRow
    {
        /// <remarks/>
        public string bzdm { get; set; }

        /// <remarks/>
        public string ksdm { get; set; }

        /// <remarks/>
        public string ksmc { get; set; }

        /// <remarks/>
        public int zjpb { get; set; }

        /// <remarks/>
        public decimal ghje { get; set; }

        /// <remarks/>
        public string zswz { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }
    }
}

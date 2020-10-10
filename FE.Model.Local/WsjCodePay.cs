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
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public  class WsjCodePayIn
    {
        /// <remarks/>
        public string yyjsls { get; set; }

        /// <remarks/>
        public decimal pay { get; set; }

        /// <remarks/>
        public string zffs { get; set; }
    }


}

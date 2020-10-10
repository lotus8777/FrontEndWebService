using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FE.Model.Local
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class WsjGhclIn
    {
        /// <remarks/>
        public uint zzjgdm { get; set; }

        /// <remarks/>
        public GhclBrxx brxx { get; set; }

        /// <remarks/>
        public GhclGhxx ghxx { get; set; }

        /// <remarks/>
        public int source_type { get; set; }

        public decimal ghje { get; set; }
        public string mode { get; set; }
      
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GhclBrxx
    {
        /// <remarks/>
        public string sfzh { get; set; }

        /// <remarks/>
        public string brxm { get; set; }

        /// <remarks/>
        public int brxb { get; set; }

        /// <remarks/>
        public string smkno { get; set; }

        /// <remarks/>
        public string grbh { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime csny { get; set; }

        /// <remarks/>
        public string jtdz { get; set; }

        /// <remarks/>
        public string gddh { get; set; }

        /// <remarks/>
        public string tel { get; set; }

        /// <remarks/>
        public string ybkh { get; set; }

        /// <remarks/>
        public int cardtype { get; set; }

        /// <remarks/>
        public string cardnum { get; set; }

        /// <remarks/>
        public string yldylb { get; set; }

        [XmlIgnore]
        public int brid { get; set; }
        [XmlIgnore]
        public int brxz { get; set; }
        [XmlIgnore]
        public int qybr { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GhclGhxx
    {
        /// <remarks/>
        public int ghlb { get; set; }

        /// <remarks/>
        public string bzdm { get; set; }

        /// <remarks/>
        public string ksdm { get; set; }

        /// <remarks/>
        public string ghly { get; set; }

        /// <remarks/>
        public string ysdm { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime gzrq { get; set; }

        /// <remarks/>
        public int zblb { get; set; }

        /// <remarks/>
        public int jzxh { get; set; }

        /// <remarks/>
        public string jzsj { get; set; }

        /// <remarks/>
        public string jzsj2 { get; set; }

        /// <remarks/>
        public int zjpb { get; set; }

        /// <remarks/>
        public decimal ghje { get; set; }

        public string swyyxh { get; set; }
        [XmlIgnore]
        public int ghxh { get; set; }
        [XmlIgnore]
        public string jzhm { get; set; }
        [XmlIgnore]
        public int yj01xh { get; set; }
        [XmlIgnore]
        public int mzks { get; set; }
        [XmlIgnore]
        public decimal yylb { get; set; }
        [XmlIgnore]
        public int yyxh { get; set; }
        [XmlIgnore]
        public string pzhm { get; set; }

        [XmlIgnore]
        public int[] yj02xh { get; set; }
        /// <summary>
        /// 费用序号，费用金额
        /// </summary>
        [XmlIgnore]
        public List<Tuple<int, decimal>> ZlfList { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "YyghInterface")]
    public class WsjGhclOut
    {
        /// <remarks/>
        public int RtnValue { get; set; } = 1;

        /// <remarks/>
        public string bzxx { get; set; } = "门诊预约挂号成功";

        [XmlElement("interface")]
        public GhclOutInterface GhclOutInterface { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GhclOutInterface
    {
        /// <remarks/>
        public GhclOutInterfaceRow row { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GhclOutInterfaceRow
    {
        /// <remarks/>
        public int ghxh { get; set; }
    }


}

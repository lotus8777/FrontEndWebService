using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace FE.Model.Local
{
    //class WsjGhclInParam

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class WsjGhclInParam
    {
        /// <remarks/>
        public string zzjgdm { get; set; }

        /// <remarks/>
        public interfaceBrxx brxx { get; set; }

        /// <remarks/>
        public interfaceGhxx ghxx { get; set; }

        /// <remarks/>
        public int source_type { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class interfaceBrxx
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
        public int yldylb { get; set; }
        [XmlIgnore]
        public int brid { get; set; }
        [XmlIgnore]
        public int brxz { get; set; }
        [XmlIgnore]
        public int qybr { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class interfaceGhxx
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
        public int[] yj02xh
        {
            get;
            set;

        }

        /// <summary>
        /// 费用序号，费用金额
        /// </summary>
        [XmlIgnore]
        public IList<Tuple<int, decimal>> ZlfList { get; set; }
    }


}

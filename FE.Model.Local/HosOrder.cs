using System;
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
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public class HosOrderIn
    {
        /// <remarks/>
        [XmlElement(DataType = "integer")]
        public string actnumber { get; set; }
    }

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "interface")]
    public class HosOrderOut
    {
        /// <remarks/>
        public byte RtnValue { get; set; } = 1;

        /// <remarks/>
        public string bzxx { get; set; } = "获取住院病人医嘱成功";

        /// <remarks/>
        public HosOrderHead head { get; set; }

        /// <remarks/>
        [XmlArrayItem("item", IsNullable = false)]
        public List<HosOrderItem> list { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class HosOrderHead
    {
        /// <remarks/>
        public decimal jzlsh { get; set; }

        /// <remarks/>
        public string mzzyhm { get; set; }

        /// <remarks/>
        public string brxm { get; set; }

        /// <remarks/>
        public int brxb { get; set; }

        /// <remarks/>
        public int brnl { get; set; }

        /// <remarks/>
        public string nldw { get; set; }

        /// <remarks/>
        public string lxdh { get; set; }

        /// <remarks/>
        public string jtdz { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class HosOrderItem
    {
        /// <remarks/>
        public decimal ORDER_NO { get; set; }

        /// <remarks/>
        public decimal ORDER_SUB_NO { get; set; }

        /// <summary>
        /// 长期标志
        /// </summary>
        public int REPEAT_INDICATOR { get; set; }

        /// <remarks/>
        public string ORDER_CLASS { get; set; }

        /// <remarks/>
        public string ORDER_TEXT { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        public string DOSAGE { get; set; }

       /// <summary>
       /// 服药方式
       /// </summary>
        public string ADMINISTRATION { get; set; }

        /// <remarks/>
        public string START_DATE_TIME { get; set; }

        /// <remarks/>
        public string STOP_DATE_TIME { get; set; }

        /// <remarks/>
        public string DURATION { get; set; }

        /// <remarks/>
        public string FREQUENCY { get; set; }

        /// <remarks/>
        public string FREQ_DETAIL { get; set; }

        /// <remarks/>
        public string PERFORM_SCHEDULE { get; set; }

        /// <remarks/>
        public string PERFORM_RESULT { get; set; }

        /// <remarks/>
        public string ORDERING_DEPT { get; set; }

        /// <remarks/>
        public string DOCTOR { get; set; }

        /// <remarks/>
        public string STOP_DOCTOR { get; set; }

        /// <remarks/>
        public string NURSE { get; set; }

        /// <remarks/>
        public string STOP_NURSE { get; set; }

        /// <remarks/>
        public int ORDER_STATUS { get; set; }

        /// <remarks/>
        public int DRUG_BILLING_ATTR { get; set; }

        /// <remarks/>
        public int BILLING_ATTR { get; set; }

        /// <remarks/>
        public string LAST_PERFORM_DATE_TIME { get; set; }
    }
}

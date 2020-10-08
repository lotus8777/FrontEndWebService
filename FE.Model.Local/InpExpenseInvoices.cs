using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FE.Model.Local
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "YyghInterface")]
    public class InpExpenseInvoices
    {
        /// <remarks/>
        public int RtnValue { get; set; } = 1;

        /// <remarks/>
        public string bzxx { get; set; } = "获取出院费用清单成功";

        /// <remarks/>
        [XmlElement("interface")]
        public InpExpenseInvoicesInterface InpInterface { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InpExpenseInvoicesInterface
    {
        /// <remarks/>
        public string HospitalCode { get; set; }

        /// <remarks/>
        public string Operator { get; set; }

        /// <remarks/>
        public string CVX_CardType { get; set; }

        /// <remarks/>
        public string ICInfo { get; set; } 

        /// <remarks/>
        public int ChargeType { get; set; } = 4;

        /// <remarks/>
        public string YLLB { get; set; }

        /// <remarks/>
        public string DisAudNo { get; set; } = "";

        /// <remarks/>
        public decimal FeeTotal { get; set; }

        /// <remarks/>
        public decimal ZFFY { get; set; }

        /// <remarks/>
        public decimal yjje { get; set; }

        /// <remarks/>
        public int DisMark { get; set; } = 0;
        
        /// <remarks/>
        public string OperatorName { get; set; } 

        /// <remarks/>
        public InpClinic Clinic { get; set; }

        //public InpFeeDetail zyfymx { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InpClinic
    {
        /// <remarks/>
        public string ClinicNo { get; set; }

        /// <remarks/>
        public DateTime ClinicDate { get; set; }

        /// <remarks/>
        public string DeptCode { get; set; }

        /// <remarks/>
        public string DeptGBCode { get; set; }

        /// <remarks/>
        public string DeptName { get; set; }

        /// <remarks/>
        public string DocName { get; set; }

        /// <remarks/>
        public string DocSfzh { get; set; }

        /// <remarks/>
        public string DisCode { get; set; }

        /// <remarks/>
        public string DisName { get; set; }

        /// <remarks/>
        public string DisDesc { get; set; }

        /// <remarks/>
        public int FeeDetail { get; set; }
        [XmlArrayItem("Item")]
        public string[] CYZD { get; set; }
    }

    ///// <remarks/>
    //[Serializable()]
    //[System.ComponentModel.DesignerCategory("code")]
    //[XmlType(AnonymousType = true)]
    //public class InpDiagnosis
    //{
    //    /// <remarks/>
    //    public string Item { get; set; }
    //}

    ///// <remarks/>
    //[Serializable()]
    //[System.ComponentModel.DesignerCategory("code")]
    //[XmlType(AnonymousType = true)]
    //public class InpFeeDetail
    //{
    //    /// <remarks/>
    //    [XmlElement("I01", typeof(decimal))]
    //    [XmlElement("I04", typeof(decimal))]
    //    [XmlElement("I05", typeof(decimal))]
    //    [XmlElement("I06", typeof(decimal))]
    //    [XmlElement("I07", typeof(decimal))]
    //    [XmlElement("I08", typeof(decimal))]
    //    [XmlElement("I10", typeof(decimal))]
    //    [XmlElement("I99", typeof(decimal))]
    //    [XmlChoiceIdentifier("ItemsElementName")]
    //    public decimal[] Items { get; set; }

    //}



}

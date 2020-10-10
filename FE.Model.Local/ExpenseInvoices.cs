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
    public class ExpenseInvoicesIn
    {
        /// <remarks/>
        public int acttype { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer")]
        public string actnumber { get; set; }

        /// <remarks/>
        public ExpenseInfo list { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ExpenseInfo
    {
        /// <remarks/>
        public string actnumber { get; set; }

        /// <remarks/>
        public string jzlsh { get; set; }

        /// <remarks/>
        public string mzzyhm { get; set; }
    }


    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "YyghInterface")]
    public class ExpenseInvoices
    {
        /// <remarks/>
        public int RtnValue { get; set; } = 1;

        /// <remarks/>
        public string bzxx { get; set; } = "获取出院费用清单成功";

        /// <remarks/>
        [XmlElement("interface")]
        public ExpenseInterface Interface { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ExpenseInterface
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
    [Serializable]
    [DesignerCategory("code")]
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




}

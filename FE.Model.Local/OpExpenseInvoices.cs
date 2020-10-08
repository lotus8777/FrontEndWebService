using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
namespace FE.Model.Local
{
    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <summary>
    ///     门诊费用清单
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "YyghInterface")]
    public class OpExpenseInvoices
    {
        /// <remarks />
        public byte RtnValue { get; set; } = 1;
        /// <remarks />
        public string bzxx { get; set; } = "获取门诊费用清单成功";
        /// <remarks />
        [XmlElement("interface")]
        public OpExpenseInvoicesInterface OpInterface { get; set; }
    }
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OpExpenseInvoicesInterface
    {
        /// <remarks />
        public string HospitalCode { get; set; }
        /// <remarks />
        public string Operator { get; set; }
        /// <remarks />
        public string CVX_CardType { get; set; }
        /// <remarks />
        public string ICInfo { get; set; }
        /// <remarks />
        public byte ChargeType { get; set; } = 1;
        /// <remarks />
        public byte YLLB { get; set; } = 11;
        /// <remarks />
        public string DisAudNo { get; set; }
        /// <remarks />
        public decimal FeeTotal { get; set; }
        /// <remarks />
        public byte ZFFY { get; set; } = 0;
        /// <remarks />
        public byte yjje { get; set; } = 0;
        /// <remarks />
        public byte DisMark { get; set; } = 0;
        /// <remarks />
        public string OperatorName { get; set; }
        /// <remarks />
        public OpClinic Clinic { get; set; }
        /// <remarks />
        [XmlArrayItem("Detail", IsNullable = false)]
        public List<OpFeeDetail> list { get; set; }
    }
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OpClinic
    {
        public string ClinicNo { get; set; }
        /// <remarks />
        public DateTime ClinicDate { get; set; }
        /// <remarks />
        public string DeptCode { get; set; }
        /// <remarks />
        public string DeptGBCode { get; set; }
        /// <remarks />
        public string DeptName { get; set; }
        /// <remarks />
        public string DocName { get; set; }
        /// <remarks />
        public string DocSfzh { get; set; }
        /// <remarks />
        public string DisCode { get; set; }
        /// <remarks />
        public string DisName { get; set; }
        /// <remarks />
        public string DisDesc { get; set; }
        public int FeeDetail { get; set; }
        [XmlArrayItem("Item")] public List<string> CYZD { get; set; }
    }
    /// <summary>
    ///     门诊费用明细
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OpFeeDetail
    {
        /// <remarks />
        public int Type { get; set; }
        /// <remarks />
        public string Name { get; set; }
        /// <remarks />
        public int itemNo { get; set; }
        /// <remarks />
        public decimal itemCost { get; set; }
        /// <remarks />
        [XmlElement("item")]
        public List<OpFeeDetailItem> Item { get; set; }
    }
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OpFeeDetailItem
    {
        /// <remarks />
        public decimal itemNumber { get; set; }
        /// <remarks />
        public int XMLB { get; set; }
        /// <remarks />
        public string SFLB { get; set; }
        /// <remarks />
        public int DetailType { get; set; }
        /// <remarks />
        public string ItemCode { get; set; }
        /// <remarks />
        public string ItemHospCode { get; set; }
        /// <remarks />
        public string ItemHospName { get; set; }
        /// <remarks />
        public int SDFlag { get; set; }
        /// <remarks />
        public decimal Price { get; set; }
        /// <remarks />
        public decimal Amount { get; set; }
        /// <remarks />
        public decimal Amount_T { get; set; }
        /// <remarks />
        public string Unit { get; set; }
        /// <remarks />
        public string Spec { get; set; }
        /// <remarks />
        public string MedType { get; set; }
        /// <remarks />
        public decimal ItemTotal { get; set; }
        /// <remarks />
        public int SelfDeal { get; set; }
        /// <remarks />
        public int SelfPay { get; set; }
        /// <remarks />
        public string DayTimes { get; set; }
        /// <remarks />
        public decimal Dosage { get; set; }
        /// <remarks />
        public decimal SelfPayRate { get; set; }
        /// <remarks />
        public int QEZFBZ { get; set; }
        /// <remarks />
        public string DisAudNo_DJ { get; set; }
        /// <remarks />
        public string Usage { get; set; }
    }
}
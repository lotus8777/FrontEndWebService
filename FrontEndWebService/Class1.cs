using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FrontEndWebService
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class YYGHinterface
    {
        public int RtnValue { get; set; }

        /// <remarks/>
        public string bzxx { get; set; }

        /// <remarks/>
        public uint presc_no { get; set; }

        /// <remarks/>
        public int CHARGE_INDICATOR { get; set; }

        /// <remarks/>
        public PrescriptionItems prescriptionItems { get; set; }

    }

    /// <remarks/>
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]

    public class PrescriptionItems
    {
        /// <remarks/>
        public InterfacePrescriptionItemsHead head { get; set; }

        /// <remarks/>
        public InterfacePrescriptionItemsList list { get; set; }
    }

    /// <remarks/>
    //[SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[XmlTypeAttribute(AnonymousType = true)]
    public class InterfacePrescriptionItemsHead
    {
        /// <remarks/>
        public uint cfhm { get; set; }

        /// <remarks/>
        public uint mzhm { get; set; }

        /// <remarks/>
        public string brxm { get; set; }

        /// <remarks/>
        public int brxb { get; set; }

        /// <remarks/>
        public int brnl { get; set; }

        /// <remarks/>
        public string nldw { get; set; }

        /// <remarks/>
        public ulong lxdh { get; set; }

        /// <remarks/>
        public string jtdz { get; set; }

        /// <remarks/>
        public string kfrq { get; set; }

        /// <remarks/>
        public string kfys { get; set; }

        /// <remarks/>
        public int CFLX { get; set; }

        /// <remarks/>
        public string DIAGNOSE { get; set; }
    }

    /// <remarks/>
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class InterfacePrescriptionItemsList
    {
        /// <remarks/>
        public IList<InterfacePrescriptionItemsListItem> items { get; set; }
    }

    /// <remarks/>
    //[SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[XmlTypeAttribute(AnonymousType = true)]
    public class InterfacePrescriptionItemsListItem
    {
        /// <remarks/>
        public int YPZH { get; set; }

        /// <remarks/>
        public uint ITEM_NO { get; set; }

        /// <remarks/>
        public int ITEM_CLASS { get; set; }

        /// <remarks/>
        public string ITEM_CLASS_NAME { get; set; }

        /// <remarks/>
        public object isps { get; set; }

        /// <remarks/>
        public object psjg { get; set; }

        /// <remarks/>
        public object psry { get; set; }

        /// <remarks/>
        public object kssj { get; set; }

        /// <remarks/>
        public object jssj { get; set; }

        /// <remarks/>
        public ushort DRUG_CODE { get; set; }

        /// <remarks/>
        public string DRUG_NAME { get; set; }

        /// <remarks/>
        public int FIRM_ID { get; set; }

        /// <remarks/>
        public string DRUG_SPEC { get; set; }

        /// <remarks/>
        public decimal AMOUNT { get; set; }

        /// <remarks/>
        public string UNITS { get; set; }

        /// <remarks/>
        public int REPETITION { get; set; }

        /// <remarks/>
        public decimal DOSAGE { get; set; }

        /// <remarks/>
        public string DOSAGE_UNITS { get; set; }

        /// <remarks/>
        public string ADMINISTRATION { get; set; }

        /// <remarks/>
        public string FREQUENCY { get; set; }

        /// <remarks/>
        public int DAYS { get; set; }

        /// <remarks/>
        public object yszt { get; set; }

        /// <remarks/>
        public object PROVIDED_INDICATOR { get; set; }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FE.Model.Local
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "interface")]
    public class HosPayConfirmIn
    {


        public string actnumber { get; set; }


        public InterfaceList list { get; set; }


        public string ElectronicInvoiceNumber { get; set; }


        public int acttype { get; set; }


        public string PayLSH { get; set; }


        public string PayDateTime { get; set; }



        public InterfacePayJsxx PayJsxx { get; set; }


        public InterfaceYbJsxx YbJsxx { get; set; }


        public InterfaceFyqd fyqd { get; set; }
        [XmlIgnore]
        public OtherPayConfirmPara OtherPara { get; set; }

    }
    
    public class OtherPayConfirmPara
    {
        /// <summary>
        /// ms_mzxx出入主键值
        /// </summary>
        public int MsMzxx_Mzxh { get; set; }
        public string Fphm { get; set; }
        /// <summary>
        /// BOC_JSJL插入主键值
        /// </summary>
        public int BocJsjl_Jlxh { get; set; }

        public int Ybpb { get; set; } 
        /// <summary>
        /// hzyb_jsjl出入序号值
        /// </summary>
        public int HzybJsjl_Jylsh { get; set; }
        /// <summary>
        /// 默认自费病人性质代码1000
        /// </summary>
        public int Brxz { get; set; } = 1000;
        /// <summary>
        /// ys_mz_jzls表里的就诊序号
        /// </summary>
        public decimal  YsMzJzls_Jzxh { get; set; }
        /// <summary>
        /// 就诊类型2门诊，3住院
        /// </summary>
        public int Jzlx { get; set; }
        /// <summary>
        /// zy_tbkk序号
        /// </summary>
        public int ZyTbkk_Jkxh { get; set; }

        /// <summary>
        /// ZY_ZYJS序号
        /// </summary>
        public int ZyJs_Jlxh { get; set; }

        public string Sjhm { get; set; }
        /// <summary>
        /// zy_tbkk sjhm字段
        /// </summary>
        public string Jsjk { get; set; }
        /// <summary>
        /// 住院结算次数
        /// </summary>
        public int Jscs { get; set; }
    }



    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceList
    {

        public string actnumber { get; set; }


        public uint jzlsh { get; set; }


        public string mzzyhm { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfacePayJsxx
    {

        public int PayMethod { get; set; }


        public string PayMethodName { get; set; }


        public string ThirdPayDate { get; set; }


        public decimal ZFFY { get; set; }

        /// <summary>
        /// 预缴金额
        /// </summary>
        public decimal yjje { get; set; }

        /// <summary>
        /// 费用总额
        /// </summary>
        public decimal Fyze { get; set; }

        /// <summary>
        /// 报销金额
        /// </summary>
        public decimal Bxje { get; set; }

        /// <summary>
        /// 自负金额
        /// </summary>
        public decimal Zfje { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceYbJsxx
    {

        public string CVX_CardType { get; set; }


        public string HospitalCode { get; set; }


        public string Operator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ZXJYLSH { get; set; }


        public string JZLSH { get; set; }


        public string YYJYLSH { get; set; }


        public string JSLSH { get; set; }

        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BusnissCycle { get; set; }


        public string GRBH { get; set; }


        public string DJH { get; set; }


        public string YLLB { get; set; }


        public int DisMark { get; set; }


        public string PayDate { get; set; }


        public InterfaceYbJsxxIcinfo icinfo { get; set; }


        public InterfaceYbJsxxResultInfo ResultInfo { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceYbJsxxIcinfo
    {

        public string icxx { get; set; }


        public string grbh { get; set; }


        public string sfzh { get; set; }


        public string brxm { get; set; }


        public string ylrylb { get; set; }


        public string fjrylb { get; set; }


        public double dnzhye { get; set; }


        public double lnzhye { get; set; }


        public string tcqydm { get; set; }


        public string ybkh { get; set; }


        public string SMKH { get; set; }


        public int brxb { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceYbJsxxResultInfo
    {
        /// <summary>
        /// 费用总额
        /// </summary>
        public decimal FeeTotal { get; set; }

        /// <summary>
        /// 当年帐户支付
        /// </summary>
        public decimal DNZHJJ { get; set; }

        /// <summary>
        /// 历年帐户支付
        /// </summary>
        public decimal LNZHJJ { get; set; }

        /// <summary>
        /// 医保基金支付
        /// </summary>
        public decimal YBJJZF { get; set; }

        /// <summary>
        /// 个人现金支付
        /// </summary>
        public decimal PersonPay { get; set; }

        /// <summary>
        /// 自理总额
        /// </summary>
        public decimal SelfDealTotal { get; set; }
        /// <summary>
        /// 自费总额
        /// </summary>

        public decimal SelfPayTotal { get; set; }

        /// <summary>
        /// 超限价自费
        /// </summary>
        public decimal CXJZF { get; set; }

        /// <summary>
        /// 当年帐户余额
        /// </summary>
        public decimal CurAccYE { get; set; }

        /// <summary>
        /// 历年帐户余额
        /// </summary>
        public decimal OldAccYE { get; set; }

        /// <summary>
        /// 医保费用
        /// </summary>
        public decimal SSPay { get; set; }

        /// <summary>
        /// 报销金额
        /// </summary>
        public decimal ReimPay { get; set; }

        /// <summary>
        /// 首付费用
        /// </summary>
        public decimal FirstPay { get; set; }

        /// <summary>
        /// 重病基金
        /// </summary>
        public decimal ZBJJ { get; set; }

        /// <summary>
        /// 困难救助基金
        /// </summary>
        public decimal KNJZJJ { get; set; }

        /// <summary>
        /// 伤残基金支出自理
        /// </summary>
        public decimal SCJJZL { get; set; }

        /// <summary>
        /// 伤残基金支出自负
        /// </summary>
        public decimal SCJJZF { get; set; }

        /// <summary>
        /// 劳模基金
        /// </summary>
        public decimal LMJJ { get; set; }

        /// <summary>
        /// 保健基金
        /// </summary>
        public decimal BJJJ { get; set; }

        /// <summary>
        /// 统筹基金
        /// </summary>
        public decimal TCJJ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal QFBZZF { get; set; }


        public decimal XJZFZL { get; set; }


        public decimal XJZFZF { get; set; }


        public decimal LNZHZFZL { get; set; }


        public decimal LNZHZFZF { get; set; }


        public decimal ZFJE { get; set; }


        public decimal BJJJZF { get; set; }


        public decimal BFZZFY { get; set; }


        public decimal BFZZLZF { get; set; }


        public decimal BNDZFLJS { get; set; }

        /// <summary>
        /// 建国前老工人基金
        /// </summary>
        public decimal LGRJJ { get; set; }

        /// <summary>
        /// 医院承担费用
        /// </summary>
        public decimal YYCDFY { get; set; }

        /// <summary>
        /// 其他基金支出
        /// </summary>
        public decimal QTJJ { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceFyqd
    {

        [XmlArrayItem("Detail", IsNullable = false)]
        public List<InterfaceFyqdDetail> list { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceFyqdDetail
    {

        public int Type { get; set; }


        public string Name { get; set; }


        public uint itemNo { get; set; }


        public decimal itemCost { get; set; }


        [XmlElement("item")]
        public List<InterfaceFyqdDetailItem> item { get; set; }
    }


    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InterfaceFyqdDetailItem
    {

        public uint itemNumber { get; set; }


        public decimal ItemTotal { get; set; }


        public decimal SelfDeal { get; set; }


        public decimal SelfPay { get; set; }


        public int SFLB { get; set; }


        public int XMLB { get; set; }


        public int QEZFBZ { get; set; }


        public decimal SelfPayRate { get; set; }


        public decimal XMXJ { get; set; }


        public int DetailType { get; set; }


        public string ItemHospCode { get; set; }


        public string ItemHospName { get; set; }


        public string ItemCode { get; set; }


        public decimal Price { get; set; }


        public decimal Amount { get; set; }


        public string MedType { get; set; }


        public string Spec { get; set; }


        public string Unit { get; set; }


        public int SDFlag { get; set; }


        public string DisAudNo_DJ { get; set; }


        public decimal Dosage { get; set; }


        public int DayTimes { get; set; }


        public decimal Amount_T { get; set; }

        public string BZXX { get; set; }
    }


}

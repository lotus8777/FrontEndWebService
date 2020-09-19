using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    [Table("ms_brda")]
    public class MzBrda
    {
        [Key]
        public decimal brid { get; set; }

        public string mzhm { get; set; }
        public string brxm { get; set; }
        public string fyzh { get; set; }
        public string sfzh { get; set; }
        public decimal? brxz { get; set; }
        public decimal? brxb { get; set; }
        public DateTime? csny { get; set; }
        public decimal? hyzk { get; set; }
        public decimal? zydm { get; set; }
        public decimal? mzdm { get; set; }
        public decimal? xxdm { get; set; }
        public decimal? gmyw { get; set; }
        public decimal? dwxh { get; set; }
        public string dwmc { get; set; }
        public string dwdh { get; set; }
        public string dwyb { get; set; }
        public string hkdz { get; set; }
        public string jtdh { get; set; }
        public string hkyb { get; set; }
        public decimal? jzcs { get; set; }
        public DateTime? jzrq { get; set; }
        public DateTime? czrq { get; set; }
        public string jzkh { get; set; }
        public string grbh_yh { get; set; }
        public string bxh_yh { get; set; }
        public decimal? rylb_yh { get; set; }
        public string lbmc_yh { get; set; }
        public decimal? gwyjb { get; set; }
        public string ybkh { get; set; }
        public string icmw { get; set; }
        public string icxx { get; set; }
        public string ickh { get; set; }
        public string grbh { get; set; }
        public string nbkh { get; set; }
        public string bxhm { get; set; }
        public string cabzlx { get; set; }
        public string cajzlx { get; set; }
        public string cahmlx { get; set; }
        public string caxsbz { get; set; }
        public string cazh { get; set; }
        public string cazjlx { get; set; }
        public string cayldh { get; set; }
        public decimal? cadxbz { get; set; }
        public string bxlx { get; set; }
        public decimal? grzhye { get; set; }
        public string kzhm { get; set; }
        public string rylxmc { get; set; }
        public string xzqydm { get; set; }
        public string rylb_fy { get; set; }
        public decimal? jdksdm { get; set; }
        public DateTime? jdrq { get; set; }
        public int? dwbz { get; set; }
        public int? drpb { get; set; }
        public int? kdpb { get; set; }
        public string blbbh { get; set; }
        public string phone { get; set; }
        public decimal? qybr { get; set; }
        public decimal? dasc { get; set; }
        public string cardxh { get; set; }
        public decimal? jkda { get; set; }
        public string bllx { get; set; }
        public string dbz { get; set; }
        public string dyzt { get; set; }
        public string cardno { get; set; }
        public string rylb { get; set; }
        public string YLDY { get; set; }
        public string jzdz_sheng_bm { get; set; }
        public string jzdz_shi_bm { get; set; }
        public string jzdz_xian_bm { get; set; }
        public string jzdz_jiedao_bm { get; set; }
        public string jzdz_sheng { get; set; }
        public string jzdz_shi { get; set; }
        public string jzdz_xian { get; set; }
        public string jzdz_jiedao { get; set; }
        public string jzdz_cun { get; set; }
        public string jzdz_lupaihao { get; set; }
        public string JHDH { get; set; }
        public string JHRM { get; set; }
        public string ZJHM { get; set; }
        public string HKDZ_QTDZ { get; set; }
        public string XZZ_DH { get; set; }
        public string XZZ_YB { get; set; }
        public string ZXR { get; set; }
        public string SBHM { get; set; }
        public string DBRM { get; set; }
        public string LXDZ { get; set; }
        public string LXRM { get; set; }
        public string LXDH { get; set; }
        public string JDR { get; set; }
        public string XZZ_QTDZ { get; set; }
        public string JHDZ { get; set; }
        public string MPIID { get; set; }
        public string ZFBID { get; set; }
        public DateTime? ZXSJ { get; set; }
        public DateTime? JDSJ { get; set; }
        public DateTime? XGSJ { get; set; }
        public decimal? ZFBSFQY { get; set; }
        public decimal? GLZH { get; set; }
        public decimal? SSSCD { get; set; }
        public decimal? BSLZT { get; set; }
        public decimal? BRSG { get; set; }
        public decimal? HKDZ_X { get; set; }
        public decimal? HKDZ_SQS { get; set; }
        public decimal? XZZ_S { get; set; }
        public decimal? JGDM_S { get; set; }
        public decimal? CSD_X { get; set; }
        public decimal? CSD_S { get; set; }
        public decimal? CSD_SQS { get; set; }
        public decimal? ZXBZ { get; set; }
        public decimal? ZZTX { get; set; }
        public decimal? LXGX { get; set; }
        public decimal? JGDM { get; set; }
        public decimal? GJDM { get; set; }
        public decimal? SFDM { get; set; }
        public decimal? DBGX { get; set; }
        public decimal? JDJG { get; set; }
        public decimal? JGDM_SQS { get; set; }
        public decimal? XZZ_X { get; set; }
        public decimal? HKDZ_S { get; set; }
        public decimal? ZJLX { get; set; }
        public decimal? XZZ_SQS { get; set; }
        public decimal? GSSCD { get; set; }
        public decimal? BRTZ { get; set; }
        public string CBDXZDM { get; set; }
        public decimal? TSTDBRXZ { get; set; }

        public virtual ICollection<MzGhmx> MzGhmxCollection { get; set; }
    }
}
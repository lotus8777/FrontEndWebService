using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace FE.Model.Hrp275
{
    [Table("ms_brda")]
    public class MsBrda
    {
        [Key]
        public decimal Brid { get; set; }

        public string Mzhm { get; set; }
        public string Brxm { get; set; }
        public string Fyzh { get; set; }
        public string Sfzh { get; set; }
        public decimal? Brxz { get; set; }
        public decimal? Brxb { get; set; }
        public DateTime? Csny { get; set; }
        public decimal? Hyzk { get; set; }
        public decimal? Zydm { get; set; }
        public decimal? Mzdm { get; set; }
        public decimal? Xxdm { get; set; }
        public decimal? Gmyw { get; set; }
        public decimal? Dwxh { get; set; }
        public string Dwmc { get; set; }
        public string Dwdh { get; set; }
        public string Dwyb { get; set; }
        public string Hkdz { get; set; }
        public string Jtdh { get; set; }
        public string Hkyb { get; set; }
        public decimal? Jzcs { get; set; }
        public DateTime? Jzrq { get; set; }
        public DateTime? Czrq { get; set; }
        public string Jzkh { get; set; }

        public string Grbh_Yh { get; set; }

        public string Bxh_Yh { get; set; }

        public decimal? Rylb_Yh { get; set; }

        public string Lbmc_Yh { get; set; }
        public decimal? Gwyjb { get; set; }
        public string Ybkh { get; set; }
        public string Icmw { get; set; }
        public string Icxx { get; set; }
        public string Ickh { get; set; }
        public string Grbh { get; set; }
        public string Nbkh { get; set; }
        public string Bxhm { get; set; }
        public string Cabzlx { get; set; }
        public string Cajzlx { get; set; }
        public string Cahmlx { get; set; }
        public string Caxsbz { get; set; }
        public string Cazh { get; set; }
        public string Cazjlx { get; set; }
        public string Cayldh { get; set; }
        public decimal? Cadxbz { get; set; }
        public string Bxlx { get; set; }
        public decimal? Grzhye { get; set; }
        public string Kzhm { get; set; }
        public string Rylxmc { get; set; }
        public string Xzqydm { get; set; }
        public string Rylb_Fy { get; set; }
        public decimal? Jdksdm { get; set; }
        public DateTime? Jdrq { get; set; }
        public int? Dwbz { get; set; }
        public int? Drpb { get; set; }
        public int? Kdpb { get; set; }
        public string Blbbh { get; set; }
        public string Phone { get; set; }
        public decimal? Qybr { get; set; }
        public decimal? Dasc { get; set; }
        public string Cardxh { get; set; }
        public decimal? Jkda { get; set; }
        public string Bllx { get; set; }
        public string Dbz { get; set; }
        public string Dyzt { get; set; }
        public string Cardno { get; set; }
        public string Rylb { get; set; }
        public string Yldy { get; set; }
        public string Jzdz_Sheng_Bm { get; set; }
        public string Jzdz_Shi_Bm { get; set; }
        public string Jzdz_Xian_Bm { get; set; }
        public string Jzdz_Jiedao_Bm { get; set; }
        public string Jzdz_Sheng { get; set; }
        public string Jzdz_Shi { get; set; }
        public string Jzdz_Xian { get; set; }
        public string Jzdz_Jiedao { get; set; }
        public string Jzdz_Cun { get; set; }
        public string Jzdz_Lupaihao { get; set; }
        public string Jhdh { get; set; }
        public string Jhrm { get; set; }
        public string Zjhm { get; set; }
        public string Hkdz_Qtdz { get; set; }
        public string Xzz_Dh { get; set; }
        public string Xzz_Yb { get; set; }
        public string Zxr { get; set; }
        public string Sbhm { get; set; }
        public string Dbrm { get; set; }
        public string Lxdz { get; set; }
        public string Lxrm { get; set; }
        public string Lxdh { get; set; }
        public string Jdr { get; set; }
        public string Xzz_Qtdz { get; set; }
        public string Jhdz { get; set; }
        public string Mpiid { get; set; }
        public string Zfbid { get; set; }
        public DateTime? Zxsj { get; set; }
        public DateTime? Jdsj { get; set; }
        public DateTime? Xgsj { get; set; }
        public decimal? Zfbsfqy { get; set; }
        public decimal? Glzh { get; set; }
        public decimal? Ssscd { get; set; }
        public decimal? Bslzt { get; set; }
        public decimal? Brsg { get; set; }
        public decimal? Hkdz_X { get; set; }
        public decimal? Hkdz_Sqs { get; set; }
        public decimal? Xzz_S { get; set; }
        public decimal? Jgdm_S { get; set; }
        public decimal? Csd_X { get; set; }
        public decimal? Csd_S { get; set; }
        public decimal? Csd_Sqs { get; set; }
        public decimal? Zxbz { get; set; }
        public decimal? Zztx { get; set; }
        public decimal? Lxgx { get; set; }
        public decimal? Jgdm { get; set; }
        public decimal? Gjdm { get; set; }
        public decimal? Sfdm { get; set; }
        public decimal? Dbgx { get; set; }
        public decimal? Jdjg { get; set; }
        public decimal? Jgdm_Sqs { get; set; }
        public decimal? Xzz_X { get; set; }
        public decimal? Hkdz_S { get; set; }
        public decimal? Zjlx { get; set; }
        public decimal? Xzz_Sqs { get; set; }
        public decimal? Gsscd { get; set; }
        public decimal? Brtz { get; set; }
        public string Cbdxzdm { get; set; }
        public decimal? Tstdbrxz { get; set; }

        public virtual ICollection<MsGhmx> MzGhmxCollection { get; set; }
    }
}
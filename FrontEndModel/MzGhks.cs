using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    /// 门诊-挂号科室
    /// </summary>
    [Table("ms_ghks")]
    public  class MzGhks
    {
        [Key]
        public string ksdm { get; set; }
        public string ksmc { get; set; }
        public decimal ghlb { get; set; }
        public string pydm { get; set; }
        public string wbdm { get; set; }
        public string jxdm { get; set; }
        public string qtdm { get; set; }
        public decimal ghf { get; set; }
        public decimal zlf { get; set; }
        public decimal zjmz { get; set; }
        public decimal ghxe { get; set; }
        public decimal ygrs { get; set; }
        public decimal yyrs { get; set; }
        public DateTime? ghrq { get; set; }
        public decimal? mzks { get; set; }
        public decimal tjpb { get; set; }
        public decimal tjf { get; set; }
        public decimal mzlb { get; set; }
        public decimal? jzxh { get; set; }
        public string cjks { get; set; }
        public decimal? cflb { get; set; }
        public decimal? kswz { get; set; }
        public int? zfpb { get; set; }
        public int? zjlb { get; set; }
        public int? yybz { get; set; }
        public int? kyyts { get; set; }
        public string zjsjap { get; set; }
        public decimal? yyxe { get; set; }
        public DateTime? yyghsx1 { get; set; }
        public DateTime? yyghsx2 { get; set; }
        public string ksms { get; set; }
        public string dydm { get; set; }
        public string nlxz { get; set; }
        public string bglx { get; set; }
        public decimal? scbz { get; set; }
        public decimal? frmzbz { get; set; }
        public decimal? xspb { get; set; }
        public decimal? kfyypb { get; set; }
        public string zswz { get; set; }
        public string bzdm { get; set; }
        public decimal jgid { get; set; }
        public string ddxx { get; set; }
        public decimal? BGLX_YYH { get; set; }
        public decimal? SCBZ_YYH { get; set; }
        public string LXDH { get; set; }
        public decimal? JJRGHF { get; set; }
    
       
        public virtual ICollection<MzGhmx> ms_ghmx { get; set; }
       
        public virtual ICollection<MzYspb> ms_yspb { get; set; }
       
        public virtual ICollection<MzYygh> ms_yygh { get; set; }
    }
}

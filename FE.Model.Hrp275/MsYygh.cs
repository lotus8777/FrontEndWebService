using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 门诊预约挂号
    /// </summary>
    [Table("ms_yygh")]
    public class MsYygh
    {
        [Key]
        public decimal Yyxh { get; set; }

        public string Yymm { get; set; }
        public decimal Brid { get; set; }
        public DateTime Ghrq { get; set; }
        public string Ksdm { get; set; }
        public decimal? Zblb { get; set; }
        public string Ysdm { get; set; }
        public decimal? Yylb { get; set; }
        public decimal Ghbz { get; set; }
        public DateTime? Yyrq { get; set; }
        public decimal? Jzxh { get; set; }
        public decimal? Sbxh { get; set; }
        public decimal Zcid { get; set; }
        public string Djgh { get; set; }
        public string Pzhm { get; set; }
        public string Brxm { get; set; }
        public string Bzxx { get; set; }
        public decimal? Xwbz { get; set; }
        public decimal? Ygbz { get; set; }
        public string Lxdh { get; set; }
        public decimal? Ghsbxh { get; set; }
        public decimal? Yjsbxh { get; set; }
        public decimal? Sms { get; set; }
        public DateTime? Tzsj { get; set; }
        public decimal? Scbz { get; set; }
        public decimal? Jgid { get; set; }

        [ForeignKey("Ksdm")]
        public virtual MsGhks MzGhks { get; set; }
        [ForeignKey("Ghsbxh")]
        public virtual MsGhmx MsGhmx { get; set; }

        [ForeignKey("Yjsbxh")]
        public virtual MsYj01 MsYj01 { get; set; }
    }
}
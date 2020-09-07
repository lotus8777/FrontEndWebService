using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    /// 门诊预约挂号
    /// </summary>
    [Table("ms_yygh")]
    public class MzYygh
    {
        [Key]
        public decimal yyxh { get; set; }
        public string yymm { get; set; }
        public decimal brid { get; set; }
        public DateTime ghrq { get; set; }
        public string ksdm { get; set; }
        public decimal? zblb { get; set; }
        public string ysdm { get; set; }
        public decimal? yylb { get; set; }
        public decimal ghbz { get; set; }
        public DateTime? yyrq { get; set; }
        public decimal? jzxh { get; set; }
        public decimal? sbxh { get; set; }
        public decimal zcid { get; set; }
        public string djgh { get; set; }
        public string pzhm { get; set; }
        public string brxm { get; set; }
        public string bzxx { get; set; }
        public decimal? xwbz { get; set; }
        public decimal? ygbz { get; set; }
        public string lxdh { get; set; }
        public decimal? ghsbxh { get; set; }
        public decimal? yjsbxh { get; set; }
        public decimal? sms { get; set; }
        public DateTime? tzsj { get; set; }
        public decimal? scbz { get; set; }
        public decimal? JGID { get; set; }
        [ForeignKey("ksdm")]
        public virtual MzGhks MzGhks { get; set; }
    }
}

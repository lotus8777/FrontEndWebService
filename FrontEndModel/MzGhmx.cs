using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    [Table("ms_ghmx")]
    public class MzGhmx
    {
        [Key]
        public decimal sbxh { get; set; }

        public decimal? brid { get; set; }
        public decimal? brxz { get; set; }
        public DateTime? ghsj { get; set; }
        public decimal? ghlb { get; set; }
        public string ksdm { get; set; }
        public string ysdm { get; set; }
        public string jzys { get; set; }
        public decimal jzxh { get; set; }
        public decimal ghcs { get; set; }
        public decimal ghje { get; set; }
        public decimal zlje { get; set; }
        public decimal zjfy { get; set; }
        public decimal blje { get; set; }
        public decimal xjje { get; set; }
        public decimal zpje { get; set; }
        public decimal zhje { get; set; }
        public decimal hbwc { get; set; }
        public decimal qtys { get; set; }
        public decimal? zhlb { get; set; }
        public decimal? jzjs { get; set; }
        public decimal? zdjg { get; set; }
        public decimal thbz { get; set; }
        public string czgh { get; set; }
        public DateTime? jzrq { get; set; }
        public DateTime? hzrq { get; set; }
        public decimal czpb { get; set; }
        public string jzhm { get; set; }
        public decimal mzlb { get; set; }
        public decimal? yybz { get; set; }
        public decimal yspb { get; set; }
        public decimal? dzsb { get; set; }
        public decimal sffs { get; set; }
        public decimal jzzt { get; set; }
        public string ywxlh { get; set; }
        public string busi_type { get; set; }
        public decimal? tsbbz { get; set; }
        public string jbbm { get; set; }
        public decimal? tcjj { get; set; }
        public decimal? grbcjj { get; set; }
        public decimal? lxjj { get; set; }
        public decimal? rylb { get; set; }
        public decimal? bljj { get; set; }
        public decimal? jrzf { get; set; }
        public decimal? jrzflx { get; set; }
        public decimal? czbz { get; set; }
        public decimal? cjbz { get; set; }
        public string yydm { get; set; }
        public decimal? ckdj { get; set; }
        public decimal? ckje { get; set; }
        public decimal? ghfxh { get; set; }
        public decimal? zlfxh { get; set; }
        public decimal? zjfxh { get; set; }
        public decimal? blfxh { get; set; }
        public decimal? ckfxh { get; set; }
        public decimal? qybr { get; set; }
        public DateTime? jzsj { get; set; }
        public decimal? zblb { get; set; }
        public decimal? qtfs { get; set; }
        public decimal? qtje { get; set; }
        public decimal? JGID { get; set; }
        public DateTime? SFSJ { get; set; }
        public decimal? JZJE { get; set; }

        [ForeignKey("brid")]
        public virtual MzBrda MzBrda { get; set; }

        [ForeignKey("ksdm")]
        public virtual MzGhks MzGhks { get; set; }
    }
}
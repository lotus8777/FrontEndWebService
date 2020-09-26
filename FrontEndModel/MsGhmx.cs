using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FE.Model.Hrp275
{

    //public class MsGhmxConfiguration : EntityTypeConfiguration<MsGhmx>
    //{
    //    public MsGhmxConfiguration()
    //    {
    //        HasKey(p => p.Sbxh); 
                
    //    }
    //}

    [Table("ms_ghmx")]
    public class MsGhmx
    {
        [Key]
        public decimal Sbxh { get; set; }

        public decimal? Brid { get; set; }
        public decimal? Brxz { get; set; }
        public DateTime? Ghsj { get; set; }
        public decimal? Ghlb { get; set; }
        public string Ksdm { get; set; }
        public string Ysdm { get; set; }
        public string Jzys { get; set; }
        public decimal Jzxh { get; set; }
        public decimal Ghcs { get; set; }
        public decimal Ghje { get; set; }
        public decimal Zlje { get; set; }
        public decimal Zjfy { get; set; }
        public decimal Blje { get; set; }
        public decimal Xjje { get; set; }
        public decimal Zpje { get; set; }
        public decimal Zhje { get; set; }
        public decimal Hbwc { get; set; }
        public decimal Qtys { get; set; }
        public decimal? Zhlb { get; set; }
        public decimal? Jzjs { get; set; }
        public decimal? Zdjg { get; set; }
        public decimal Thbz { get; set; }
        public string Czgh { get; set; }
        public DateTime? Jzrq { get; set; }
        public DateTime? Hzrq { get; set; }
        public decimal Czpb { get; set; }
        public string Jzhm { get; set; }
        public decimal Mzlb { get; set; }
        public decimal? Yybz { get; set; }
        public decimal Yspb { get; set; }
        public decimal? Dzsb { get; set; }
        public decimal Sffs { get; set; }
        public decimal Jzzt { get; set; }
        public string Ywxlh { get; set; }
        public string BusiType { get; set; }
        public decimal? Tsbbz { get; set; }
        public string Jbbm { get; set; }
        public decimal? Tcjj { get; set; }
        public decimal? Grbcjj { get; set; }
        public decimal? Lxjj { get; set; }
        public decimal? Rylb { get; set; }
        public decimal? Bljj { get; set; }
        public decimal? Jrzf { get; set; }
        public decimal? Jrzflx { get; set; }
        public decimal? Czbz { get; set; }
        public decimal? Cjbz { get; set; }
        public string Yydm { get; set; }
        public decimal? Ckdj { get; set; }
        public decimal? Ckje { get; set; }
        public decimal? Ghfxh { get; set; }
        public decimal? Zlfxh { get; set; }
        public decimal? Zjfxh { get; set; }
        public decimal? Blfxh { get; set; }
        public decimal? Ckfxh { get; set; }
        public decimal? Qybr { get; set; }
        public DateTime? Jzsj { get; set; }
        public decimal? Zblb { get; set; }
        public decimal? Qtfs { get; set; }
        public decimal? Qtje { get; set; }
        public decimal? Jgid { get; set; }
        public DateTime? Sfsj { get; set; }
        public decimal? Jzje { get; set; }

        [ForeignKey("Brid")]
        public virtual MsBrda MzBrda { get; set; }

        [ForeignKey("Ksdm")]
        public virtual MsGhks MzGhks { get; set; }
    }
}
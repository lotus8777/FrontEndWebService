using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("zy_fymx")]
    public class ZyFymx
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Jlxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zyh { get; set; }

        public DateTime Fyrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fyxh { get; set; }

        [StringLength(60)]
        public string Fymc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypcd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fysl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fydj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zjje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfje { get; set; }

        [StringLength(10)]
        public string Ysgh { get; set; }

        [StringLength(10)]
        public string Srgh { get; set; }

        [StringLength(10)]
        public string Qrgh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fybq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fyks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zxks { get; set; }

        public DateTime Jfrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yplx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fyxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jscs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yzxh { get; set; }

        public DateTime? Hzrq { get; set; }

        [StringLength(8)]
        public string Yjrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zlje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zlxz { get; set; }
        public decimal? Scbz_Yh { get; set; }

        public decimal? Cjbz { get; set; }

        [StringLength(18)]
        public string Spxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Scbz { get; set; }

        public decimal? Yjcs { get; set; }

        public decimal? Spbh { get; set; }
        public decimal? Jscs_Jcy { get; set; }

        [StringLength(20)]
        public string Wenjianbm { get; set; }

        [StringLength(20)]
        public string Hismac { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Nbsc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ckdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cksl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bzxz { get; set; }

        [StringLength(3)]
        public string Sflb { get; set; }

        [StringLength(3)]
        public string Xmdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tfxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yefbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cfts { get; set; }

        [StringLength(200)]
        public string Tsxx { get; set; }

        [StringLength(50)]
        public string Ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybzfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Wybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        [StringLength(100)]
        public string Ztmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jhh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tfgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ytsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dzbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yepb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jmbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yb_Sfkb { get; set; }

        [ForeignKey("Fyxm")]
        public virtual GySfxm GySfxm { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("ms_cf02")]
    public class MsCf02
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Sbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cfsb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypcd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cfts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Hjje { get; set; }

        public int Ypzs { get; set; }

        [Required]
        [StringLength(20)]
        public string Ycsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fygb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gytj { get; set; }

        [StringLength(20)]
        public string Ypyf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ypzh { get; set; }

        [StringLength(20)]
        public string Yfgg { get; set; }

        [StringLength(4)]
        public string Yfdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yfbz { get; set; }

        [StringLength(20)]
        public string Sjyl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Pspb { get; set; }

        public int? Yyts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ycsl2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xssl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Mrcs { get; set; }

        [StringLength(40)]
        public string Cfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ycjl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Psjg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Plxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Spbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Sjlj { get; set; }

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

        public byte? Xnfybz { get; set; }

        [StringLength(50)]
        public string Psxz { get; set; }

        [StringLength(10)]
        public string Psgh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ylbxxl { get; set; }

        public int? Ybzfpb { get; set; }

        [StringLength(10)]
        public string Kssspys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zfpb { get; set; }

        [StringLength(200)]
        public string Tsxx { get; set; }

        [StringLength(50)]
        public string Ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dffbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jmbz { get; set; }

        [StringLength(2)]
        public string Cfcfh { get; set; }

        [StringLength(100)]
        public string Ztmc { get; set; }

        [StringLength(255)]
        public string Syly { get; set; }

        [StringLength(10)]
        public string Sqys { get; set; }

        [StringLength(255)]
        public string Sfyj { get; set; }

        [StringLength(10)]
        public string Sfgh { get; set; }

        [StringLength(20)]
        public string Typh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        public DateTime? Bssj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Nwarn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yqsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sfjg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bssl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bspb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yb_Sfkb { get; set; }

        public virtual MsCf01 MsCf01 { get; set; }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FE.Model.Hrp275
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("ms_yj02")]
    public class MsYj02
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Sbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yjxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ylxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yjzx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yldj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ylsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Hjje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fygb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfbl { get; set; }

        [StringLength(255)]
        public string Bzxx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Spbh { get; set; }

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

        [StringLength(20)]
        public string Wenjianbm { get; set; }

        [StringLength(20)]
        public string Hismac { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jytcxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybzfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yjsbxh { get; set; }

        [StringLength(200)]
        public string Tsxx { get; set; }

        [StringLength(50)]
        public string Ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jmbz { get; set; }

        [StringLength(20)]
        public string Tcmc { get; set; }

        [StringLength(100)]
        public string Ztmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dzbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Djzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cxbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yb_Sfkb { get; set; }

        public virtual MsYj01 MsYj01 { get; set; }
        [ForeignKey("Ylxh")]
        public virtual GyYlsf GyYlsf { get; set; }

    }
}
namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ms_yj02
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal sbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yjxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ylxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yjzx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yldj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ylsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal hjje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fygb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfbl { get; set; }

        [StringLength(255)]
        public string bzxx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? spbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ckdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cksl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bzxz { get; set; }

        [StringLength(3)]
        public string sflb { get; set; }

        [StringLength(3)]
        public string xmdj { get; set; }

        [StringLength(20)]
        public string wenjianbm { get; set; }

        [StringLength(20)]
        public string hismac { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jytcxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ybzfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yjsbxh { get; set; }

        [StringLength(200)]
        public string tsxx { get; set; }

        [StringLength(50)]
        public string ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jmbz { get; set; }

        [StringLength(20)]
        public string TCMC { get; set; }

        [StringLength(100)]
        public string ZTMC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DZBL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DJZT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CXBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YB_SFKB { get; set; }

        public virtual ms_yj01 ms_yj01 { get; set; }
    }
}
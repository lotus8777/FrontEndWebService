namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ms_cf02
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal sbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cfsb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ypxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ypcd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cfts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ypsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ypdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal hjje { get; set; }

        public int ypzs { get; set; }

        [Required]
        [StringLength(20)]
        public string ycsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fygb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? gytj { get; set; }

        [StringLength(20)]
        public string ypyf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ypzh { get; set; }

        [StringLength(20)]
        public string yfgg { get; set; }

        [StringLength(4)]
        public string yfdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yfbz { get; set; }

        [StringLength(20)]
        public string sjyl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pspb { get; set; }

        public int? yyts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ycsl2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xssl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal mrcs { get; set; }

        [StringLength(40)]
        public string cfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ycjl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? psjg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? plxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? spbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal sjlj { get; set; }

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

        public byte? xnfybz { get; set; }

        [StringLength(50)]
        public string psxz { get; set; }

        [StringLength(10)]
        public string psgh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ylbxxl { get; set; }

        public int? ybzfpb { get; set; }

        [StringLength(10)]
        public string kssspys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zfpb { get; set; }

        [StringLength(200)]
        public string tsxx { get; set; }

        [StringLength(50)]
        public string ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dffbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jmbz { get; set; }

        [StringLength(2)]
        public string CFCFH { get; set; }

        [StringLength(100)]
        public string ZTMC { get; set; }

        [StringLength(255)]
        public string SYLY { get; set; }

        [StringLength(10)]
        public string SQYS { get; set; }

        [StringLength(255)]
        public string SFYJ { get; set; }

        [StringLength(10)]
        public string SFGH { get; set; }

        [StringLength(20)]
        public string TYPH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        public DateTime? BSSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NWARN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YQSY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SFJG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BSSL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BSPB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SYBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YB_SFKB { get; set; }

        public virtual ms_cf01 ms_cf01 { get; set; }
    }
}
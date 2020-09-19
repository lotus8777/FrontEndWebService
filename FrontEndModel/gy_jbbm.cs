namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class gy_jbbm
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal jbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dmlb { get; set; }

        [StringLength(255)]
        public string jbmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jblb { get; set; }

        [StringLength(8)]
        public string pydm { get; set; }

        [StringLength(20)]
        public string icd9 { get; set; }

        [StringLength(20)]
        public string icd10 { get; set; }

        [StringLength(10)]
        public string qtxm { get; set; }

        [StringLength(10)]
        public string fjbm { get; set; }

        [StringLength(16)]
        public string jbbm_yh { get; set; }

        public decimal? ybsy { get; set; }

        [StringLength(6)]
        public string ybbm { get; set; }

        [StringLength(10)]
        public string icd92 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bklx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sbbz { get; set; }

        [StringLength(100)]
        public string BZXX { get; set; }

        [StringLength(8)]
        public string WBDM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GZBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NLXX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NLSX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZXBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? KZFS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YXQT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YXWY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YXHZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YXZY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? XBXZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YXSW { get; set; }
    }
}
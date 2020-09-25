namespace FrontEndModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gy_ksdm")]
    public class GyKsdm
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int ksdm { get; set; }

        [StringLength(50)]
        public string ksmc { get; set; }

        [StringLength(6)]
        public string pydm { get; set; }

        [StringLength(20)]
        public string jgbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sjks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? hsks { get; set; }

        [Required]
        [StringLength(1)]
        public string mzsy { get; set; }

        [Required]
        [StringLength(1)]
        public string yjsy { get; set; }

        [Required]
        [StringLength(1)]
        public string zysy { get; set; }

        [Required]
        [StringLength(1)]
        public string bqsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? edcw { get; set; }

        [StringLength(10)]
        public string plsx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mydpjgb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mydpj { get; set; }

        [StringLength(10)]
        public string kslc { get; set; }

        [StringLength(15)]
        public string ksdh { get; set; }

        [StringLength(32)]
        public string wsjdm { get; set; }

        [StringLength(32)]
        public string ybdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jgid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BGLX_YYH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SCBZ_YYH { get; set; }

        [StringLength(20)]
        public string KSMM1 { get; set; }

        [StringLength(20)]
        public string KSMM2 { get; set; }

        [StringLength(250)]
        public string BZXX { get; set; }

        [StringLength(20)]
        public string LXDH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BQLX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CWQX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZXYBZ { get; set; }

        [StringLength(20)]
        public string WXYKT_KSDM { get; set; }

    }
}
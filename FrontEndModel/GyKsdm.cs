namespace FE.Model.Hrp275
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gy_ksdm")]
    public class GyKsdm
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int Ksdm { get; set; }

        [StringLength(50)]
        public string Ksmc { get; set; }

        [StringLength(6)]
        public string Pydm { get; set; }

        [StringLength(20)]
        public string Jgbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sjks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hsks { get; set; }

        [Required]
        [StringLength(1)]
        public string Mzsy { get; set; }

        [Required]
        [StringLength(1)]
        public string Yjsy { get; set; }

        [Required]
        [StringLength(1)]
        public string Zysy { get; set; }

        [Required]
        [StringLength(1)]
        public string Bqsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Edcw { get; set; }

        [StringLength(10)]
        public string Plsx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mydpjgb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mydpj { get; set; }

        [StringLength(10)]
        public string Kslc { get; set; }

        [StringLength(15)]
        public string Ksdh { get; set; }

        [StringLength(32)]
        public string Wsjdm { get; set; }

        [StringLength(32)]
        public string Ybdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        [Column("bglx_yyh", TypeName = "numeric")]
        public decimal? BglxYyh { get; set; }

        [Column("scbz_yyh", TypeName = "numeric")]
        public decimal? ScbzYyh { get; set; }

        [StringLength(20)]
        public string Ksmm1 { get; set; }

        [StringLength(20)]
        public string Ksmm2 { get; set; }

        [StringLength(250)]
        public string Bzxx { get; set; }

        [StringLength(20)]
        public string Lxdh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bqlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cwqx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxybz { get; set; }

        [StringLength(20)]
        [Column("wxykt_ksdm")]
        public string WxyktKsdm { get; set; }

    }
}
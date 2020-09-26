namespace FE.Model.Hrp275
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("gy_jbbm")]
    public class GyJbbm
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Jbxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Dmlb { get; set; }

        [StringLength(255)]
        public string Jbmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jblb { get; set; }

        [StringLength(8)]
        public string Pydm { get; set; }

        [StringLength(20)]
        public string Icd9 { get; set; }

        [StringLength(20)]
        public string Icd10 { get; set; }

        [StringLength(10)]
        public string Qtxm { get; set; }

        [StringLength(10)]
        public string Fjbm { get; set; }

        [StringLength(16)]
        public string JbbmYh { get; set; }

        public decimal? Ybsy { get; set; }

        [StringLength(6)]
        public string Ybbm { get; set; }

        [StringLength(10)]
        public string Icd92 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bklx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sbbz { get; set; }

        [StringLength(100)]
        public string Bzxx { get; set; }

        [StringLength(8)]
        public string Wbdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gzbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Nlxx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Nlsx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kzfs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yxqt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yxwy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yxhz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yxzy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xbxz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yxsw { get; set; }
    }
}
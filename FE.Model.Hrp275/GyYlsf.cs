namespace FE.Model.Hrp275
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gy_ylsf")]
    public class GyYlsf
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Fyxh { get; set; }

        [Required]
        [StringLength(40)]
        public string Fymc { get; set; }

        [StringLength(4)]
        public string Fydw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fygb { get; set; }

        [StringLength(8)]
        public string Pydm { get; set; }

        [StringLength(8)]
        public string Wbdm { get; set; }

        [StringLength(8)]
        public string Jxdm { get; set; }

        [StringLength(8)]
        public string Qtdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fydj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fyks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Mzsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zysy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yjsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Tjfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Txzl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [StringLength(20)]
        public string Xmbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bzjg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yjjk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jcsq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mzsq { get; set; }

        [StringLength(255)]
        public string Tsts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Lislx { get; set; }

        [StringLength(30)]
        public string Ybbm_Yh { get; set; }

        public decimal? Ybfl_Yh { get; set; }

        public decimal? Shbz_Yh { get; set; }

        [StringLength(2)]
        public string Xmgb { get; set; }

        [StringLength(20)]
        public string Nbbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bcpb { get; set; }

        [StringLength(15)]
        public string Ybdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Tjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bqdy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jyks { get; set; }

        [StringLength(10)]
        public string Cwbm { get; set; }

        [StringLength(15)]
        public string Gbbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybfl { get; set; }

        public decimal? Hmjmbl { get; set; }

        [StringLength(255)]
        public string Bz { get; set; }

        [StringLength(150)]
        public string Ylqc { get; set; }

        [StringLength(20)]
        public string Wjbm { get; set; }

        [StringLength(40)]
        public string Qbzf { get; set; }

        [StringLength(16)]
        public string Xmfl { get; set; }

        [StringLength(40)]
        public string Dwqc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Lbdm { get; set; }
        [ForeignKey("Fygb")]
        public virtual GySfxm GySfxm { get; set; }
    }
}
namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gy_ylsf")]
    public class GyYlsf
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal fyxh { get; set; }

        [Required]
        [StringLength(40)]
        public string fymc { get; set; }

        [StringLength(4)]
        public string fydw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fygb { get; set; }

        [StringLength(8)]
        public string pydm { get; set; }

        [StringLength(8)]
        public string wbdm { get; set; }

        [StringLength(8)]
        public string jxdm { get; set; }

        [StringLength(8)]
        public string qtdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fydj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fyks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal mzsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zysy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yjsy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tjfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal txzl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [StringLength(20)]
        public string xmbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bzjg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yjjk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jcsq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mzsq { get; set; }

        [StringLength(255)]
        public string tsts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? lislx { get; set; }

        [StringLength(30)]
        public string ybbm_yh { get; set; }

        public decimal? ybfl_yh { get; set; }

        public decimal? shbz_yh { get; set; }

        [StringLength(2)]
        public string xmgb { get; set; }

        [StringLength(20)]
        public string nbbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bcpb { get; set; }

        [StringLength(15)]
        public string ybdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bqdy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jyks { get; set; }

        [StringLength(10)]
        public string cwbm { get; set; }

        [StringLength(15)]
        public string gbbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ybfl { get; set; }

        public decimal? hmjmbl { get; set; }

        [StringLength(255)]
        public string bz { get; set; }

        [StringLength(150)]
        public string YLQC { get; set; }

        [StringLength(20)]
        public string WJBM { get; set; }

        [StringLength(40)]
        public string QBZF { get; set; }

        [StringLength(16)]
        public string XMFL { get; set; }

        [StringLength(40)]
        public string DWQC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LBDM { get; set; }

        public virtual GyKsdm gy_ksdm { get; set; }
    }
}
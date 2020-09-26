namespace FE.Model.Hrp275
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("gy_ygdm")]
    public class GyYgdm
    {
        [Key]
        [StringLength(10)]
        public string Ygdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ksdm { get; set; }

        [StringLength(10)]
        public string Ygxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ygxb { get; set; }

        public DateTime? Csny { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ygzw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ygjb { get; set; }

        [StringLength(6)]
        public string Pydm { get; set; }

        [StringLength(6)]
        public string Wbdm { get; set; }

        [StringLength(6)]
        public string Jxdm { get; set; }

        [StringLength(6)]
        public string Qtdm { get; set; }

        [Required]
        [StringLength(1)]
        public string Kcfq { get; set; }

        [Required]
        [StringLength(1)]
        public string Mzyq { get; set; }

        [Required]
        [StringLength(1)]
        public string Jsyq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zjpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zjfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "text")]
        public string Ysjj { get; set; }

        public DateTime? JzsjSw { get; set; }

        public DateTime? JzsjXw { get; set; }

        [Required]
        [StringLength(10)]
        public string Ygbh { get; set; }

        [Required]
        [StringLength(50)]
        public string Ygmm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ksyq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mydpj { get; set; }

        public int? Ysdj { get; set; }

        [StringLength(10)]
        public string Ygbm { get; set; }

        [StringLength(10)]
        public string Ksdh { get; set; }

        [StringLength(15)]
        public string Ygsj { get; set; }

        [StringLength(10)]
        public string Ysxl { get; set; }

        [StringLength(200)]
        public string Ysjl { get; set; }

        [StringLength(200)]
        public string Ysjs { get; set; }

        [StringLength(1)]
        public string Bglx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Scbz { get; set; }

        public int? Cfdps { get; set; }

        public int? Cfdpsxx { get; set; }

        [StringLength(100)]
        public string Zsbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BglxYyh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ScbzYyh { get; set; }

        [StringLength(5)]
        public string Yszc { get; set; }

        [StringLength(50)]
        public string Cjr { get; set; }

        [StringLength(20)]
        public string Sfz { get; set; }

        [StringLength(20)]
        public string Lxdh { get; set; }

        [StringLength(6)]
        public string Zxjs { get; set; }

        [StringLength(20)]
        public string Sjhm { get; set; }

        [StringLength(20)]
        public string Zxdm { get; set; }

        [StringLength(20)]
        public string Zxmm { get; set; }

        [StringLength(250)]
        public string Bzxx { get; set; }

        [StringLength(60)]
        public string Yxdz { get; set; }

        public DateTime? Cjsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tskssq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kssq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ygjs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jtbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cjjg { get; set; }

        [StringLength(30)]
        public string Ybzh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Agreedoctor { get; set; }

        [StringLength(40)]
        public string Xyyszh { get; set; }

        [StringLength(30)]
        public string Sfzh { get; set; }

        [StringLength(30)]
        public string Sjzh { get; set; }
    }
}
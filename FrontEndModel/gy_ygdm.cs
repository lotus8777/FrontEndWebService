namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class gy_ygdm
    {
        [Key]
        [StringLength(10)]
        public string ygdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ksdm { get; set; }

        [StringLength(10)]
        public string ygxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ygxb { get; set; }

        public DateTime? csny { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ygzw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ygjb { get; set; }

        [StringLength(6)]
        public string pydm { get; set; }

        [StringLength(6)]
        public string wbdm { get; set; }

        [StringLength(6)]
        public string jxdm { get; set; }

        [StringLength(6)]
        public string qtdm { get; set; }

        [Required]
        [StringLength(1)]
        public string kcfq { get; set; }

        [Required]
        [StringLength(1)]
        public string mzyq { get; set; }

        [Required]
        [StringLength(1)]
        public string jsyq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zjpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zjfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [Column(TypeName = "text")]
        public string ysjj { get; set; }

        public DateTime? jzsj_sw { get; set; }

        public DateTime? jzsj_xw { get; set; }

        [Required]
        [StringLength(10)]
        public string ygbh { get; set; }

        [Required]
        [StringLength(50)]
        public string ygmm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ksyq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mydpj { get; set; }

        public int? ysdj { get; set; }

        [StringLength(10)]
        public string ygbm { get; set; }

        [StringLength(10)]
        public string ksdh { get; set; }

        [StringLength(15)]
        public string ygsj { get; set; }

        [StringLength(10)]
        public string ysxl { get; set; }

        [StringLength(200)]
        public string ysjl { get; set; }

        [StringLength(200)]
        public string ysjs { get; set; }

        [StringLength(1)]
        public string bglx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? scbz { get; set; }

        public int? cfdps { get; set; }

        public int? cfdpsxx { get; set; }

        [StringLength(100)]
        public string zsbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jgid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BGLX_YYH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SCBZ_YYH { get; set; }

        [StringLength(5)]
        public string yszc { get; set; }

        [StringLength(50)]
        public string CJR { get; set; }

        [StringLength(20)]
        public string SFZ { get; set; }

        [StringLength(20)]
        public string LXDH { get; set; }

        [StringLength(6)]
        public string ZXJS { get; set; }

        [StringLength(20)]
        public string SJHM { get; set; }

        [StringLength(20)]
        public string ZXDM { get; set; }

        [StringLength(20)]
        public string ZXMM { get; set; }

        [StringLength(250)]
        public string BZXX { get; set; }

        [StringLength(60)]
        public string YXDZ { get; set; }

        public DateTime? CJSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TSKSSQ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? KSSQ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YGJS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JTBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CJJG { get; set; }

        [StringLength(30)]
        public string YBZH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? agreedoctor { get; set; }

        [StringLength(40)]
        public string xyyszh { get; set; }

        [StringLength(30)]
        public string SFZH { get; set; }

        [StringLength(30)]
        public string sjzh { get; set; }
    }
}
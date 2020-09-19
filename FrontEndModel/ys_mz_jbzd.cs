namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ys_mz_jbzd
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal jlbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? brbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jbbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zdlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jbzg { get; set; }

        [Required]
        [StringLength(10)]
        public string ysdm { get; set; }

        public DateTime zdsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zdlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zxlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? znxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fjbs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zzbj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? qzbz { get; set; }

        public DateTime? qzsj { get; set; }

        [StringLength(50)]
        public string YWBS { get; set; }

        [StringLength(60)]
        public string FJMC { get; set; }

        [StringLength(2)]
        public string JBZH { get; set; }

        [StringLength(255)]
        public string JBMC { get; set; }

        [StringLength(100)]
        public string BZXX { get; set; }

        [StringLength(255)]
        public string MSZD { get; set; }

        [StringLength(20)]
        public string ICD { get; set; }

        [StringLength(10)]
        public string ZFYS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        public DateTime? ZFSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QMXH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DYBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BKZT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZDXH { get; set; }

        public virtual ys_mz_jzls ys_mz_jzls { get; set; }
    }
}
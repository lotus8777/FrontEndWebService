namespace FrontEndModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ys_mz_jzls
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ys_mz_jzls()
        {
            ys_mz_jbzd = new HashSet<ys_mz_jbzd>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ghxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal brbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ksdm { get; set; }

        [Required]
        [StringLength(10)]
        public string ysdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zyzd { get; set; }

        public DateTime kssj { get; set; }

        public DateTime? jssj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal jzzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yyxh { get; set; }

        public DateTime? fzrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ghfz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jzlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? brqx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? crb { get; set; }

        [StringLength(1)]
        public string bz { get; set; }

        [StringLength(6)]
        public string ghks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? crbsb { get; set; }

        [StringLength(100)]
        public string bzxx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xuey1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xuey2 { get; set; }

        public int? bk_crb { get; set; }

        public int? bk_jsb { get; set; }

        public int? bk_tnb { get; set; }

        public int? bk_gxy { get; set; }

        public int? bk_zl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zhiye { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rzzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ycs_ys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ycs_cs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zybk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? gybk { get; set; }

        [StringLength(60)]
        public string actnumber { get; set; }

        [StringLength(30)]
        public string pbzxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pbzgx { get; set; }

        [StringLength(20)]
        public string pbzdh { get; set; }

        [StringLength(50)]
        public string pbzdz { get; set; }

        [StringLength(50)]
        public string pbzdw { get; set; }

        [StringLength(255)]
        public string zdmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? czpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jzbz { get; set; }

        public DateTime? fbrq { get; set; }

        [StringLength(20)]
        public string RYNL { get; set; }

        [StringLength(10)]
        public string LKDJ { get; set; }

        [StringLength(12)]
        public string BRCH { get; set; }

        [StringLength(255)]
        public string MQZD { get; set; }

        [StringLength(10)]
        public string TZLX { get; set; }

        [StringLength(10)]
        public string RKDJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        public DateTime? BLCJSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QYBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? XYCLBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BRLY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LKQX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LKZD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZXZT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FZXH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZDLX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JZQJSWBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JZQJBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZGQK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ys_mz_jbzd> ys_mz_jbzd { get; set; }
    }
}
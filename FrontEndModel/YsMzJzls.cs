using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("ys_mz_jzls")]
    public class YsMzJzls
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YsMzJzls()
        {
            YsMzJbzd = new HashSet<YsMzJbzd>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ghxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Brbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ksdm { get; set; }

        [Required]
        [StringLength(10)]
        public string Ysdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zyzd { get; set; }

        public DateTime Kssj { get; set; }

        public DateTime? Jssj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jzzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yyxh { get; set; }

        public DateTime? Fzrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ghfz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brqx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Crb { get; set; }

        [StringLength(1)]
        public string Bz { get; set; }

        [StringLength(6)]
        public string Ghks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Crbsb { get; set; }

        [StringLength(100)]
        public string Bzxx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xuey1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xuey2 { get; set; }
        [Column("bk_crb")]
        public int? Bk_Crb { get; set; }
        [Column("bk_jsb")]
        public int? Bk_Jsb { get; set; }
        [Column("bk_tnb")]
        public int? Bk_Tnb { get; set; }
        [Column("bk_gxy")]
        public int? Bk_Gxy { get; set; }
        [Column("bk_zl")]
        public int? Bk_Zl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zhiye { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rzzt { get; set; }

        [Column("ycs_ys",TypeName = "numeric")]
        public decimal? Ycs_Ys { get; set; }

        [Column("ycs_cs",TypeName = "numeric")]
        public decimal? Ycs_Cs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zybk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gybk { get; set; }

        [StringLength(60)]
        public string Actnumber { get; set; }

        [StringLength(30)]
        public string Pbzxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Pbzgx { get; set; }

        [StringLength(20)]
        public string Pbzdh { get; set; }

        [StringLength(50)]
        public string Pbzdz { get; set; }

        [StringLength(50)]
        public string Pbzdw { get; set; }

        [StringLength(255)]
        public string Zdmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Czpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzbz { get; set; }

        public DateTime? Fbrq { get; set; }

        [StringLength(20)]
        public string Rynl { get; set; }

        [StringLength(10)]
        public string Lkdj { get; set; }

        [StringLength(12)]
        public string Brch { get; set; }

        [StringLength(255)]
        public string Mqzd { get; set; }

        [StringLength(10)]
        public string Tzlx { get; set; }

        [StringLength(10)]
        public string Rkdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        public DateTime? Blcjsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Qybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xyclbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Lkqx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Lkzd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzqjswbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzqjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zgqk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YsMzJbzd> YsMzJbzd { get; set; }
    }
}
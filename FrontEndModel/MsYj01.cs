namespace FE.Model.Hrp275
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ms_yj01")]
    public class MsYj01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsYj01()
        {
            MsYj02 = new HashSet<MsYj02>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Yjxh { get; set; }

        [StringLength(10)]
        public string Tjhm { get; set; }

        [StringLength(12)]
        public string Fphm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brid { get; set; }

        [StringLength(40)]
        public string Brxm { get; set; }

        public DateTime? Kdrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ksdm { get; set; }

        [StringLength(10)]
        public string Ysdm { get; set; }

        public DateTime? Zxrq { get; set; }

        [Column(TypeName = "numeric")]
        public int? Zxks { get; set; }

        [StringLength(10)]
        public string Zxys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zxpb { get; set; }

        [StringLength(10)]
        public string Hjgh { get; set; }

        [StringLength(250)]
        public string Zysx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yjgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cfbz { get; set; }

        [StringLength(250)]
        public string Hymx { get; set; }

        [StringLength(20)]
        public string Yjph { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sqwh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fjgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fjlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bwid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jbid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Djzt { get; set; }

        [StringLength(20)]
        public string Jzkh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sqid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Qybr { get; set; }

        [StringLength(4)]
        public string Fyly { get; set; }

        [StringLength(40)]
        public string Sqdmc { get; set; }

        [StringLength(1024)]
        public string Xml { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        public DateTime? Zfsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Djly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tjfl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MsYj02> MsYj02 { get; set; }
        [ForeignKey("Zxks")]
        public virtual GyKsdm GyKsdm { get; set; }
    }
}
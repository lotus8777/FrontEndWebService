namespace FrontEndModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ms_yj01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ms_yj01()
        {
            ms_yj02 = new HashSet<ms_yj02>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal yjxh { get; set; }

        [StringLength(10)]
        public string tjhm { get; set; }

        [StringLength(12)]
        public string fphm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? brid { get; set; }

        [StringLength(40)]
        public string brxm { get; set; }

        public DateTime? kdrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ksdm { get; set; }

        [StringLength(10)]
        public string ysdm { get; set; }

        public DateTime? zxrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zxks { get; set; }

        [StringLength(10)]
        public string zxys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zxpb { get; set; }

        [StringLength(10)]
        public string hjgh { get; set; }

        [StringLength(250)]
        public string zysx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yjgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cfbz { get; set; }

        [StringLength(250)]
        public string hymx { get; set; }

        [StringLength(20)]
        public string yjph { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sqwh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fjgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fjlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bwid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jbid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal djzt { get; set; }

        [StringLength(20)]
        public string jzkh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sqid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? qybr { get; set; }

        [StringLength(4)]
        public string FYLY { get; set; }

        [StringLength(40)]
        public string SQDMC { get; set; }

        [StringLength(1024)]
        public string XML { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        public DateTime? ZFSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JZFY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DJLY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TJFL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_yj02> ms_yj02 { get; set; }
    }
}
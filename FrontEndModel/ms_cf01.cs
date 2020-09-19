namespace FrontEndModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ms_cf01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ms_cf01()
        {
            ms_cf02 = new HashSet<ms_cf02>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal cfsb { get; set; }

        [StringLength(10)]
        public string cfhm { get; set; }

        [StringLength(12)]
        public string fphm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? mzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cflx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? brid { get; set; }

        [StringLength(40)]
        public string brxm { get; set; }

        public DateTime kfrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cfts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ksdm { get; set; }

        [StringLength(10)]
        public string ysdm { get; set; }

        public DateTime? fyrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fyck { get; set; }

        [StringLength(10)]
        public string hjgh { get; set; }

        [StringLength(10)]
        public string pygh { get; set; }

        [StringLength(10)]
        public string fygh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal pybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cfgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yfsb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tscf { get; set; }

        public int? tslx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal yxpb { get; set; }

        [StringLength(20)]
        public string jzkh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? brtz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sydybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cflb { get; set; }

        [StringLength(100)]
        public string jbzd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sydybz1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? qybr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cgdy { get; set; }

        [StringLength(10)]
        public string HDGH { get; set; }

        [StringLength(255)]
        public string KJLYLY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        public DateTime? HDRQ { get; set; }

        public DateTime? ZFSJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? KJLY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BRXZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DJYBZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DJLY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYSM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_cf02> ms_cf02 { get; set; }
    }
}
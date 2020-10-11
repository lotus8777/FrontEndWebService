using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("ms_cf01")]
    public class MsCf01
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Cfsb { get; set; }

        [StringLength(10)]
        public string Cfhm { get; set; }

        [StringLength(12)]
        public string Fphm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cflx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brid { get; set; }

        [StringLength(40)]
        public string Brxm { get; set; }

        public DateTime Kfrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cfts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ksdm { get; set; }

        [StringLength(10)]
        public string Ysdm { get; set; }

        public DateTime? Fyrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fyck { get; set; }

        [StringLength(10)]
        public string Hjgh { get; set; }

        [StringLength(10)]
        public string Pygh { get; set; }

        [StringLength(10)]
        public string Fygh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Pybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cfgl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yfsb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tscf { get; set; }

        public int? Tslx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yxpb { get; set; }

        [StringLength(20)]
        public string Jzkh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brtz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sydybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cflb { get; set; }

        [StringLength(100)]
        public string Jbzd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sydybz1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Qybr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cgdy { get; set; }

        [StringLength(10)]
        public string Hdgh { get; set; }

        [StringLength(255)]
        public string Kjlyly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        public DateTime? Hdrq { get; set; }

        public DateTime? Zfsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brxz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Djybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Djly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tysm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<MsCf02> MsCf02 { get; set; }

        [ForeignKey("Ksdm")]
        public virtual GyKsdm GyKsdm { get; set; }

    }
}
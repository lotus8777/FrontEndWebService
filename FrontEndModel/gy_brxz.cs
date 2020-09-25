
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{

    [Table("gy_brxz")]
    public class GyBrxz
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public gy_brxz()
        //{
        //    this.gy_fybr = new HashSet<gy_fybr>();
        //    this.gy_fydw = new HashSet<gy_fydw>();
        //    this.gy_ypjy = new HashSet<gy_ypjy>();
        //    this.GyZfbl = new HashSet<GyZfbl>();
        //}
        [Key]
        public decimal brxz { get; set; }
        public string xzmc { get; set; }
        public decimal sjxz { get; set; }
        public decimal gsxz { get; set; }
        public string pydm { get; set; }
        public string zhpb { get; set; }
        public decimal dbpb { get; set; }
        public decimal mzsy { get; set; }
        public decimal zysy { get; set; }
        public decimal ssbl { get; set; }
        public decimal cfxj { get; set; }
        public decimal cfxe { get; set; }
        public string plsx { get; set; }
        public decimal? ybpb { get; set; }
        public decimal? qypb { get; set; }
        public string XZDL { get; set; }
        public string MPICODE { get; set; }
        public decimal? TFFBJY { get; set; }
        public decimal? ybgb { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<gy_fybr> gy_fybr { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<gy_fydw> gy_fydw { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<gy_ypjy> gy_ypjy { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GyZfbl> GyZfbl { get; set; }
    }
}

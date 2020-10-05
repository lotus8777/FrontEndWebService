
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
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
        public decimal Brxz { get; set; }
        public string Xzmc { get; set; }
        public decimal Sjxz { get; set; }
        public decimal Gsxz { get; set; }
        public string Pydm { get; set; }
        public string Zhpb { get; set; }
        public decimal Dbpb { get; set; }
        public decimal Mzsy { get; set; }
        public decimal Zysy { get; set; }
        public decimal Ssbl { get; set; }
        public decimal Cfxj { get; set; }
        public decimal Cfxe { get; set; }
        public string Plsx { get; set; }
        public decimal? Ybpb { get; set; }
        public decimal? Qypb { get; set; }
        public string Xzdl { get; set; }
        public string Mpicode { get; set; }
        public decimal? Tffbjy { get; set; }
        public decimal? Ybgb { get; set; }

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

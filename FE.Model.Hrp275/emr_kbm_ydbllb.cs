//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrontEndModel
{
    using System;
    using System.Collections.Generic;
    
    public  class emr_kbm_ydbllb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_kbm_ydbllb()
        {
            this.emr_kbm_bllb = new HashSet<emr_kbm_bllb>();
        }
    
        public string ydlbbm { get; set; }
        public string ydlbmc { get; set; }
        public decimal bllx { get; set; }
        public decimal blfz { get; set; }
        public decimal bjqlb { get; set; }
        public decimal dywd { get; set; }
        public string zyplxh { get; set; }
        public string cyplxh { get; set; }
        public decimal zyplsx { get; set; }
        public decimal cyplsx { get; set; }
        public Nullable<System.DateTime> ydsj { get; set; }
        public string bzxx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_kbm_bllb> emr_kbm_bllb { get; set; }
    }
}
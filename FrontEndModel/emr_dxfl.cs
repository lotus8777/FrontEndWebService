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
    
    public  class emr_dxfl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_dxfl()
        {
            this.emr_dxxm = new HashSet<emr_dxxm>();
        }
    
        public decimal flxh { get; set; }
        public decimal xmlb { get; set; }
        public string flmc { get; set; }
        public decimal zxzt { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_dxxm> emr_dxxm { get; set; }
    }
}

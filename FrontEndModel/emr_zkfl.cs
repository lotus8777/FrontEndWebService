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
    
    public  class emr_zkfl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_zkfl()
        {
            this.emr_zkbz = new HashSet<emr_zkbz>();
            this.emr_zkks = new HashSet<emr_zkks>();
        }
    
        public decimal zkfl { get; set; }
        public decimal zxlb { get; set; }
        public string flbm { get; set; }
        public string flmc { get; set; }
        public string pydm { get; set; }
        public string wbdm { get; set; }
        public string qtdm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_zkbz> emr_zkbz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_zkks> emr_zkks { get; set; }
    }
}
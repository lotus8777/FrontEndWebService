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
    
    public  class hs_cb_kmsz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hs_cb_kmsz()
        {
            this.hs_cb_cbbl_xm = new HashSet<hs_cb_cbbl_xm>();
        }
    
        public string kmdm { get; set; }
        public string pzlx { get; set; }
        public decimal cbbl { get; set; }
        public decimal srbl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hs_cb_cbbl_xm> hs_cb_cbbl_xm { get; set; }
    }
}
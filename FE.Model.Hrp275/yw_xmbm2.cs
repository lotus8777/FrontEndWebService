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
    
    public  class yw_xmbm2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yw_xmbm2()
        {
            this.yw_dxzk2 = new HashSet<yw_dxzk2>();
        }
    
        public string xmbm { get; set; }
        public string xmmc { get; set; }
        public string dlbm { get; set; }
        public string dlmc { get; set; }
        public string flbm { get; set; }
        public string flmc { get; set; }
        public Nullable<int> bz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yw_dxzk2> yw_dxzk2 { get; set; }
    }
}

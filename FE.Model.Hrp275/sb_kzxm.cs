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
    
    public  class sb_kzxm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sb_kzxm()
        {
            this.sb_szmx_ext = new HashSet<sb_szmx_ext>();
        }
    
        public decimal xmxh { get; set; }
        public string kfsb { get; set; }
        public string xmmc { get; set; }
        public Nullable<decimal> xmlx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sb_szmx_ext> sb_szmx_ext { get; set; }
    }
}

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
    
    public  class sb_gzxz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sb_gzxz()
        {
            this.sb_wxd = new HashSet<sb_wxd>();
        }
    
        public decimal xzxh { get; set; }
        public string xzmc { get; set; }
        public string pydm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sb_wxd> sb_wxd { get; set; }
    }
}

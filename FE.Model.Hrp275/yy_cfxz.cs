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
    
    public  class yy_cfxz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yy_cfxz()
        {
            this.yy_xzmx = new HashSet<yy_xzmx>();
        }
    
        public decimal xyfa { get; set; }
        public Nullable<decimal> zyh { get; set; }
        public Nullable<decimal> zkxh { get; set; }
        public string famc { get; set; }
        public Nullable<System.DateTime> sysj { get; set; }
    
        public virtual yy_brxx yy_brxx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yy_xzmx> yy_xzmx { get; set; }
    }
}

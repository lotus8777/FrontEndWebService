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
    
    public  class hl_jyjh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hl_jyjh()
        {
            this.hl_jydx = new HashSet<hl_jydx>();
        }
    
        public decimal jyjhbh { get; set; }
        public string jhxm { get; set; }
        public Nullable<System.DateTime> qssj { get; set; }
        public Nullable<System.DateTime> zzsj { get; set; }
        public string zxdx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hl_jydx> hl_jydx { get; set; }
    }
}

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
    
    public  class zy_zlxz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zy_zlxz()
        {
            this.zy_xzry = new HashSet<zy_xzry>();
        }
    
        public decimal xzxh { get; set; }
        public string xzmc { get; set; }
        public Nullable<decimal> ssks { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public string PYDM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zy_xzry> zy_xzry { get; set; }
    }
}

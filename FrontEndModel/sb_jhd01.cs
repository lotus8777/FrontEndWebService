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
    
    public  class sb_jhd01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sb_jhd01()
        {
            this.sb_jhd02 = new HashSet<sb_jhd02>();
        }
    
        public decimal jhdh { get; set; }
        public string kfsb { get; set; }
        public decimal jhld { get; set; }
        public System.DateTime jhrq { get; set; }
        public Nullable<System.DateTime> sprq { get; set; }
        public string czgh { get; set; }
        public string spgh { get; set; }
        public Nullable<decimal> spbz { get; set; }
        public string bzxx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sb_jhd02> sb_jhd02 { get; set; }
    }
}

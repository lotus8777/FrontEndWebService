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
    
    public  class sb_zjd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sb_zjd()
        {
            this.sb_jyxm = new HashSet<sb_jyxm>();
        }
    
        public decimal zjdh { get; set; }
        public string kfsb { get; set; }
        public decimal zjlx { get; set; }
        public decimal zbxh { get; set; }
        public string jyjl { get; set; }
        public System.DateTime zjrq { get; set; }
        public string czgh { get; set; }
        public string fhgh { get; set; }
        public Nullable<decimal> fhbz { get; set; }
        public Nullable<System.DateTime> fhrq { get; set; }
        public string bzxx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sb_jyxm> sb_jyxm { get; set; }
    }
}

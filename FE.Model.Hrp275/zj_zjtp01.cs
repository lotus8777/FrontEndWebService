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
    
    public  class zj_zjtp01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zj_zjtp01()
        {
            this.zj_zjtp02 = new HashSet<zj_zjtp02>();
        }
    
        public string pzdh { get; set; }
        public Nullable<decimal> cfbh { get; set; }
        public decimal zjbh { get; set; }
        public string zjph { get; set; }
        public Nullable<System.DateTime> pzrq { get; set; }
        public string ysgh { get; set; }
        public string pzgh { get; set; }
        public string jldw { get; set; }
        public Nullable<decimal> pzzl { get; set; }
    
        public virtual zj_cfxx zj_cfxx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zj_zjtp02> zj_zjtp02 { get; set; }
    }
}
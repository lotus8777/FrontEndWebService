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
    
    public  class zj_yfqy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zj_yfqy()
        {
            this.zj_yfmx = new HashSet<zj_yfmx>();
        }
    
        public int fjh { get; set; }
        public string zjph { get; set; }
        public decimal jydh { get; set; }
        public Nullable<decimal> tjbz { get; set; }
        public Nullable<decimal> qydw { get; set; }
        public string sjyy { get; set; }
        public string jyxm { get; set; }
        public string qyz { get; set; }
        public Nullable<System.DateTime> rq { get; set; }
        public string bz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zj_yfmx> zj_yfmx { get; set; }
    }
}
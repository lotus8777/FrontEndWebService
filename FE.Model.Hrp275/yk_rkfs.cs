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
    
    public  class yk_rkfs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yk_rkfs()
        {
            this.yk_rk01 = new HashSet<yk_rk01>();
        }
    
        public decimal xtsb { get; set; }
        public decimal rkfs { get; set; }
        public string fsmc { get; set; }
        public Nullable<decimal> rkdh { get; set; }
        public Nullable<decimal> ysdh { get; set; }
        public decimal grpb { get; set; }
        public string sbfh { get; set; }
        public decimal djfs { get; set; }
        public string djgs { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> DYFS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yk_rk01> yk_rk01 { get; set; }
    }
}

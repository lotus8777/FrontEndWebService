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
    
    public  class yf_ckfs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yf_ckfs()
        {
            this.yf_ck01 = new HashSet<yf_ck01>();
        }
    
        public decimal yfsb { get; set; }
        public decimal ckfs { get; set; }
        public string fsmc { get; set; }
        public decimal ckdh { get; set; }
        public string pydm { get; set; }
        public decimal xgpb { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> DYFS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yf_ck01> yf_ck01 { get; set; }
    }
}

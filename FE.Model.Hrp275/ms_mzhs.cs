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
    
    public  class ms_mzhs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ms_mzhs()
        {
            this.ms_mzmx = new HashSet<ms_mzmx>();
        }
    
        public decimal ksdm { get; set; }
        public string ysdm { get; set; }
        public decimal tjfs { get; set; }
        public System.DateTime gzrq { get; set; }
        public decimal jcd { get; set; }
        public decimal xyf { get; set; }
        public decimal zyf { get; set; }
        public decimal cyf { get; set; }
        public decimal hjje { get; set; }
        public decimal mzrc { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> HZXH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_mzmx> ms_mzmx { get; set; }
    }
}
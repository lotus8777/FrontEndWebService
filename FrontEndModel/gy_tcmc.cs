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
    
    public  class gy_tcmc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gy_tcmc()
        {
            this.gy_tcmx = new HashSet<gy_tcmx>();
        }
    
        public decimal tcxh { get; set; }
        public string tcmc { get; set; }
        public string pydm { get; set; }
        public decimal tclx { get; set; }
        public Nullable<decimal> ksdm { get; set; }
        public string XMFL { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gy_tcmx> gy_tcmx { get; set; }
    }
}

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
    
    public  class emr_jbzt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_jbzt()
        {
            this.emr_jbztmx = new HashSet<emr_jbztmx>();
        }
    
        public decimal ztid { get; set; }
        public string ztbh { get; set; }
        public string ztmc { get; set; }
        public string pydm { get; set; }
        public string wbdm { get; set; }
        public string qtdm { get; set; }
        public decimal zxbz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_jbztmx> emr_jbztmx { get; set; }
    }
}

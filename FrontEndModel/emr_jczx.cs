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
    
    public  class emr_jczx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_jczx()
        {
            this.emr_jcsfdz = new HashSet<emr_jcsfdz>();
        }
    
        public decimal jczxid { get; set; }
        public decimal zlxmid { get; set; }
        public decimal jcbwid { get; set; }
        public Nullable<decimal> jcffid { get; set; }
        public decimal tzzh { get; set; }
        public string tzmc { get; set; }
        public Nullable<decimal> zfpb { get; set; }
        public string ZYSX { get; set; }
        public string zyddygs { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_jcsfdz> emr_jcsfdz { get; set; }
        public virtual emr_zlxm emr_zlxm { get; set; }
    }
}

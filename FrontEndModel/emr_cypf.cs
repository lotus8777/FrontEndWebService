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
    
    public  class emr_cypf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_cypf()
        {
            this.emr_pfmx = new HashSet<emr_pfmx>();
        }
    
        public decimal pfid { get; set; }
        public string pfmc { get; set; }
        public Nullable<decimal> yzld { get; set; }
        public string mrpc { get; set; }
        public Nullable<decimal> mrjf { get; set; }
        public Nullable<decimal> mrff { get; set; }
        public Nullable<decimal> mrzl { get; set; }
        public decimal gslb { get; set; }
        public string gsdm { get; set; }
        public string pydm { get; set; }
        public string wbdm { get; set; }
        public string qtdm { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> KLJBZ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_pfmx> emr_pfmx { get; set; }
    }
}

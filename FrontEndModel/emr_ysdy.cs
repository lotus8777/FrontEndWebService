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
    
    public  class emr_ysdy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_ysdy()
        {
            this.emr_dysy = new HashSet<emr_dysy>();
        }
    
        public decimal dybs { get; set; }
        public decimal dylb { get; set; }
        public string dydm { get; set; }
        public string dymc { get; set; }
        public decimal flbs { get; set; }
        public string dygh { get; set; }
        public System.DateTime dysj { get; set; }
        public decimal dyzt { get; set; }
        public string qrgh { get; set; }
        public Nullable<System.DateTime> qrsj { get; set; }
        public Nullable<decimal> sjbs { get; set; }
        public string bzxx { get; set; }
        public Nullable<decimal> zymz { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_dysy> emr_dysy { get; set; }
    }
}
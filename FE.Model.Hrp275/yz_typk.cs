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
    
    public  class yz_typk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yz_typk()
        {
            this.yz_ypbm = new HashSet<yz_ypbm>();
        }
    
        public decimal ypxh { get; set; }
        public decimal xtsb { get; set; }
        public string ypmc { get; set; }
        public string ypgg { get; set; }
        public string ypdw { get; set; }
        public decimal tsyp { get; set; }
        public decimal yplb { get; set; }
        public decimal ypsx { get; set; }
        public decimal gcsl { get; set; }
        public decimal dcsl { get; set; }
        public string ypbm { get; set; }
        public string pydm { get; set; }
    
        public virtual yz_ypsx yz_ypsx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yz_ypbm> yz_ypbm { get; set; }
    }
}
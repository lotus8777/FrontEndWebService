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
    
    public  class yf_yflb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yf_yflb()
        {
            this.yf_ckbh = new HashSet<yf_ckbh>();
            this.yf_lyfs = new HashSet<yf_lyfs>();
        }
    
        public decimal yfsb { get; set; }
        public string yfmc { get; set; }
        public decimal xtsb { get; set; }
        public decimal bzlb { get; set; }
        public decimal xyqx { get; set; }
        public decimal zyqx { get; set; }
        public decimal cyqx { get; set; }
        public decimal ptfy { get; set; }
        public decimal cydy { get; set; }
        public decimal jzyy { get; set; }
        public decimal yjfy { get; set; }
        public decimal xylyfs { get; set; }
        public decimal zylyfs { get; set; }
        public decimal sjglbz { get; set; }
        public decimal tpn { get; set; }
        public decimal sjkf { get; set; }
        public string lyks { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yf_ckbh> yf_ckbh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yf_lyfs> yf_lyfs { get; set; }
    }
}

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
    
    public  class ys_mz_blxd01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ys_mz_blxd01()
        {
            this.ys_mz_blxd02 = new HashSet<ys_mz_blxd02>();
        }
    
        public decimal xdbh { get; set; }
        public string xdmc { get; set; }
        public string srdm { get; set; }
        public string xdlb { get; set; }
        public decimal sslb { get; set; }
        public string ssdm { get; set; }
        public decimal gljb { get; set; }
        public decimal zfbz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ys_mz_blxd02> ys_mz_blxd02 { get; set; }
    }
}

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
    
    public  class yk_ypkzzc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yk_ypkzzc()
        {
            this.yk_ypkzzc_yp = new HashSet<yk_ypkzzc_yp>();
            this.yk_ypkzzc_cs = new HashSet<yk_ypkzzc_cs>();
        }
    
        public string csdm { get; set; }
        public string csmc { get; set; }
        public decimal qfyp { get; set; }
        public decimal qfxz { get; set; }
        public decimal qfmk { get; set; }
        public string tsxx { get; set; }
        public decimal kzdj { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yk_ypkzzc_yp> yk_ypkzzc_yp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yk_ypkzzc_cs> yk_ypkzzc_cs { get; set; }
    }
}

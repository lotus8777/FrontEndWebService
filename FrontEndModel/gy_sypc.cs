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
    
    public  class gy_sypc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gy_sypc()
        {
            this.gy_pczq = new HashSet<gy_pczq>();
            this.gy_zxsj = new HashSet<gy_zxsj>();
        }
    
        public string pcbm { get; set; }
        public string pcmc { get; set; }
        public decimal mrcs { get; set; }
        public Nullable<decimal> jgrs { get; set; }
        public decimal zxzq { get; set; }
        public decimal atfy { get; set; }
        public decimal sjfw { get; set; }
        public Nullable<decimal> plxh { get; set; }
        public string pcmczw { get; set; }
        public string RZXZQ { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public string ZXSJ { get; set; }
        public Nullable<decimal> KCXBZ { get; set; }
        public Nullable<decimal> RLZ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gy_pczq> gy_pczq { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gy_zxsj> gy_zxsj { get; set; }
    }
}
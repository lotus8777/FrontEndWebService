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
    
    public  class ss_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ss_group()
        {
            this.ss_gright = new HashSet<ss_gright>();
            this.ss_operate_user = new HashSet<ss_operate_user>();
        }
    
        public int xtsb { get; set; }
        public string yhzm { get; set; }
        public string bzxx { get; set; }
        public string FZLB { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> JLXH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_gright> ss_gright { get; set; }
        public virtual ss_install ss_install { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_operate_user> ss_operate_user { get; set; }
    }
}

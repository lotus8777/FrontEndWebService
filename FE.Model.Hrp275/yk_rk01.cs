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
    
    public  class yk_rk01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yk_rk01()
        {
            this.yk_rk02 = new HashSet<yk_rk02>();
        }
    
        public decimal xtsb { get; set; }
        public decimal rkfs { get; set; }
        public decimal rkdh { get; set; }
        public decimal pwd { get; set; }
        public Nullable<decimal> dwxh { get; set; }
        public decimal cwpb { get; set; }
        public Nullable<decimal> fdjs { get; set; }
        public string rkbz { get; set; }
        public decimal rkpb { get; set; }
        public Nullable<System.DateTime> cgrq { get; set; }
        public Nullable<System.DateTime> lrrq { get; set; }
        public Nullable<System.DateTime> rkrq { get; set; }
        public string cggh { get; set; }
        public string czgh { get; set; }
        public decimal djfs { get; set; }
        public string djgs { get; set; }
        public string app_no { get; set; }
        public Nullable<decimal> fsbz { get; set; }
        public Nullable<System.DateTime> fssj { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        public virtual yk_jhdw yk_jhdw { get; set; }
        public virtual yk_rkfs yk_rkfs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yk_rk02> yk_rk02 { get; set; }
    }
}

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
    
    public  class yk_ck01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yk_ck01()
        {
            this.yk_ck02 = new HashSet<yk_ck02>();
        }
    
        public decimal xtsb { get; set; }
        public decimal ckfs { get; set; }
        public decimal ckdh { get; set; }
        public decimal yfsb { get; set; }
        public string ckbz { get; set; }
        public decimal ckpb { get; set; }
        public Nullable<System.DateTime> sqrq { get; set; }
        public Nullable<System.DateTime> ckrq { get; set; }
        public Nullable<decimal> ckks { get; set; }
        public string czgh { get; set; }
        public string qrgh { get; set; }
        public decimal sqtj { get; set; }
        public Nullable<System.DateTime> lyrq { get; set; }
        public decimal lypb { get; set; }
        public string lygh { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        public virtual yk_ckfs yk_ckfs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yk_ck02> yk_ck02 { get; set; }
    }
}

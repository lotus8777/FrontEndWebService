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
    
    public  class yf_ck01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yf_ck01()
        {
            this.yf_ck02 = new HashSet<yf_ck02>();
        }
    
        public decimal yfsb { get; set; }
        public decimal ckbh { get; set; }
        public decimal ckfs { get; set; }
        public decimal ckdh { get; set; }
        public Nullable<System.DateTime> ckrq { get; set; }
        public string ckbz { get; set; }
        public decimal ckpb { get; set; }
        public string czgh { get; set; }
        public Nullable<decimal> sqtj { get; set; }
        public Nullable<decimal> lypb { get; set; }
        public Nullable<System.DateTime> lyrq { get; set; }
        public string lygh { get; set; }
        public Nullable<decimal> ksdm { get; set; }
        public decimal lgzyh { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        public virtual yf_ckfs yf_ckfs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yf_ck02> yf_ck02 { get; set; }
    }
}

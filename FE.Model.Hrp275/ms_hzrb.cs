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
    
    public  class ms_hzrb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ms_hzrb()
        {
            this.ms_rbmx = new HashSet<ms_rbmx>();
            this.ms_xzmx = new HashSet<ms_xzmx>();
        }
    
        public string czgh { get; set; }
        public System.DateTime jzrq { get; set; }
        public string qzpj { get; set; }
        public decimal zjje { get; set; }
        public decimal xjje { get; set; }
        public decimal zpje { get; set; }
        public decimal zfzf { get; set; }
        public decimal qtys { get; set; }
        public decimal hbwc { get; set; }
        public Nullable<System.DateTime> hzrq { get; set; }
        public decimal fpzs { get; set; }
        public decimal mzlb { get; set; }
        public string zffp { get; set; }
        public Nullable<decimal> zfje { get; set; }
        public string tffp { get; set; }
        public Nullable<decimal> tfje { get; set; }
        public Nullable<decimal> jrzf { get; set; }
        public Nullable<decimal> rlje { get; set; }
        public Nullable<decimal> ylje { get; set; }
        public Nullable<decimal> zfb { get; set; }
        public Nullable<decimal> wx { get; set; }
        public Nullable<decimal> qt { get; set; }
        public Nullable<decimal> JGID { get; set; }
        public Nullable<decimal> ZFZS { get; set; }
        public Nullable<decimal> yhje { get; set; }
        public Nullable<decimal> cft { get; set; }
        public Nullable<decimal> yl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_rbmx> ms_rbmx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_xzmx> ms_xzmx { get; set; }
    }
}

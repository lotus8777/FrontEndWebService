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
    
    public  class ms_mzxx_tx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ms_mzxx_tx()
        {
            this.ms_sfmx_tx = new HashSet<ms_sfmx_tx>();
        }
    
        public string fphm { get; set; }
        public Nullable<System.DateTime> sfrq { get; set; }
        public Nullable<decimal> id { get; set; }
        public string brxm { get; set; }
        public Nullable<decimal> brxb { get; set; }
        public Nullable<decimal> brxz { get; set; }
        public string fyzh { get; set; }
        public Nullable<decimal> dwxh { get; set; }
        public Nullable<decimal> xjje { get; set; }
        public Nullable<decimal> zpje { get; set; }
        public Nullable<decimal> zhje { get; set; }
        public Nullable<decimal> qtys { get; set; }
        public Nullable<decimal> zhlb { get; set; }
        public Nullable<decimal> zfpb { get; set; }
        public Nullable<decimal> thpb { get; set; }
        public string fpgl { get; set; }
        public string czgh { get; set; }
        public Nullable<System.DateTime> jzrq { get; set; }
        public Nullable<System.DateTime> hzrq { get; set; }
        public Nullable<decimal> dypb { get; set; }
        public Nullable<decimal> qfbz { get; set; }
        public string qfspr { get; set; }
        public Nullable<decimal> ghgl { get; set; }
        public Nullable<decimal> jzbz { get; set; }
        public Nullable<decimal> jyxh { get; set; }
        public Nullable<decimal> mzlb { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ms_sfmx_tx> ms_sfmx_tx { get; set; }
        public virtual ms_zffp_tx ms_zffp_tx { get; set; }
    }
}

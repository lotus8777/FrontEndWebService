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
    
    public  class wz_ly01
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wz_ly01()
        {
            this.wz_ly02 = new HashSet<wz_ly02>();
        }
    
        public decimal djbh { get; set; }
        public decimal ckbh { get; set; }
        public string lzdh { get; set; }
        public Nullable<decimal> ksdm { get; set; }
        public Nullable<System.DateTime> jbsj { get; set; }
        public string jbxm { get; set; }
        public Nullable<System.DateTime> zdsj { get; set; }
        public string zdgh { get; set; }
        public Nullable<System.DateTime> yssj { get; set; }
        public string ysgh { get; set; }
        public Nullable<System.DateTime> lysj { get; set; }
        public string lygh { get; set; }
        public string djzt { get; set; }
        public string fphm { get; set; }
        public Nullable<System.DateTime> jzsj { get; set; }
        public string jzgh { get; set; }
        public string spgh { get; set; }
        public Nullable<System.DateTime> spsj { get; set; }
        public decimal lyth { get; set; }
        public string djbz { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wz_ly02> wz_ly02 { get; set; }
    }
}

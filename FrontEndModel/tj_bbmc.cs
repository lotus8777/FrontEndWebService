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
    
    public  class tj_bbmc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tj_bbmc()
        {
            this.tj_qzsz = new HashSet<tj_qzsz>();
        }
    
        public string bbbh { get; set; }
        public string bbmc { get; set; }
        public Nullable<decimal> bblb { get; set; }
        public string mrzz { get; set; }
        public Nullable<decimal> mrfx { get; set; }
        public string slck { get; set; }
        public Nullable<decimal> zfbz { get; set; }
        public Nullable<decimal> szbz { get; set; }
        public Nullable<decimal> glbz { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tj_qzsz> tj_qzsz { get; set; }
    }
}
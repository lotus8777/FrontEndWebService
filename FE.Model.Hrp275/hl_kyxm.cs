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
    
    public  class hl_kyxm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hl_kyxm()
        {
            this.hl_xmft = new HashSet<hl_xmft>();
        }
    
        public decimal xmxh { get; set; }
        public string xmmc { get; set; }
        public string kyzt { get; set; }
        public string ztjj { get; set; }
        public string sjfa { get; set; }
        public string bggl { get; set; }
        public string ktbg { get; set; }
        public string sbrh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hl_xmft> hl_xmft { get; set; }
    }
}

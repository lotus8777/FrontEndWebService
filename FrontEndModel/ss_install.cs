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
    
    public  class ss_install
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ss_install()
        {
            this.ss_database = new HashSet<ss_database>();
            this.ss_group = new HashSet<ss_group>();
            this.ss_log_info = new HashSet<ss_log_info>();
            this.ss_relation = new HashSet<ss_relation>();
        }
    
        public int xtsb { get; set; }
        public string xtmc { get; set; }
        public string xtlb { get; set; }
        public Nullable<int> xtbb { get; set; }
        public string xtaz { get; set; }
        public string cshf { get; set; }
        public string csgh { get; set; }
        public Nullable<System.DateTime> csrq { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_database> ss_database { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_group> ss_group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_log_info> ss_log_info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ss_relation> ss_relation { get; set; }
    }
}

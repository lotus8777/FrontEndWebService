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
    
    public  class emr_bl_bagd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public emr_bl_bagd()
        {
            this.emr_bl_bagdmx = new HashSet<emr_bl_bagdmx>();
            this.emr_bl_baml = new HashSet<emr_bl_baml>();
        }
    
        public decimal gdxh { get; set; }
        public string jzhm { get; set; }
        public string jsr { get; set; }
        public Nullable<System.DateTime> jsrq { get; set; }
        public string gdr { get; set; }
        public Nullable<System.DateTime> gdrq { get; set; }
        public decimal gdzt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_bl_bagdmx> emr_bl_bagdmx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emr_bl_baml> emr_bl_baml { get; set; }
    }
}

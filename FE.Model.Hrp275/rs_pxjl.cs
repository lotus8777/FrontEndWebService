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
    
    public  class rs_pxjl
    {
        public string ygdm { get; set; }
        public decimal xh { get; set; }
        public string pxxm { get; set; }
        public Nullable<System.DateTime> qssj { get; set; }
        public Nullable<System.DateTime> zzsj { get; set; }
        public Nullable<System.DateTime> lrsj { get; set; }
        public string bz { get; set; }
    
        public virtual rs_jbxx rs_jbxx { get; set; }
    }
}

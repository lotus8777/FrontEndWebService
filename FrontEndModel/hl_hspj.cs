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
    
    public  class hl_hspj
    {
        public decimal hspjdh { get; set; }
        public string hsdh { get; set; }
        public string lbbh { get; set; }
        public string hspjxm { get; set; }
        public string yqbh { get; set; }
        public Nullable<decimal> hsks { get; set; }
        public Nullable<System.DateTime> pjrq { get; set; }
        public Nullable<decimal> pjdf { get; set; }
        public string jcz { get; set; }
    
        public virtual hl_hsxmyq hl_hsxmyq { get; set; }
    }
}
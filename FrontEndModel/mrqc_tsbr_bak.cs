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
    
    public  class mrqc_tsbr_bak
    {
        public decimal jlxh { get; set; }
        public decimal zyh { get; set; }
        public Nullable<decimal> tsbm { get; set; }
        public string czgh { get; set; }
        public System.DateTime czsj { get; set; }
        public string zxgh { get; set; }
        public Nullable<System.DateTime> zxsj { get; set; }
        public Nullable<decimal> zxbz { get; set; }
    
        public virtual mrqc_tsbm_bak mrqc_tsbm_bak { get; set; }
    }
}
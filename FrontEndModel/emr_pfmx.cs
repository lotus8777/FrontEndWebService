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
    
    public  class emr_pfmx
    {
        public decimal mxid { get; set; }
        public Nullable<decimal> pfid { get; set; }
        public decimal ypxh { get; set; }
        public string ypmc { get; set; }
        public Nullable<decimal> mrsl { get; set; }
        public string sldw { get; set; }
        public Nullable<decimal> mrjz { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        public virtual emr_cypf emr_cypf { get; set; }
    }
}
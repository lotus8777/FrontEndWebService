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
    
    public  class yf_ckdb02
    {
        public decimal yfsb { get; set; }
        public decimal sqdh { get; set; }
        public decimal ypxh { get; set; }
        public decimal ypcd { get; set; }
        public decimal ypsl { get; set; }
        public decimal yfbz { get; set; }
        public string yfgg { get; set; }
        public string yfdw { get; set; }
        public decimal lsjg { get; set; }
        public decimal pfjg { get; set; }
        public Nullable<decimal> JGID { get; set; }
    
        public virtual yf_ckdb01 yf_ckdb01 { get; set; }
    }
}
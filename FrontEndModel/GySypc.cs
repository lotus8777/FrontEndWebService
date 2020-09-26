using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("gy_sypc")]
    public  class GySypc
    {
        [Key]
        public string Pcbm { get; set; }
        public string Pcmc { get; set; }
        public decimal Mrcs { get; set; }
        public decimal? Jgrs { get; set; }
        public decimal Zxzq { get; set; }
        public decimal Atfy { get; set; }
        public decimal Sjfw { get; set; }
        public decimal? Plxh { get; set; }
        public string Pcmczw { get; set; }
        public string Rzxzq { get; set; }
        public decimal? Jgid { get; set; }
        public string Zxsj { get; set; }
        public decimal? Kcxbz { get; set; }
        public decimal? Rlz { get; set; }
        
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    [Table("ms_sfmx")]
    public  class MsSfmx
    {
        [Key, Column(Order = 1)]
        public decimal Mzxh { get; set; }
        [Key, Column(Order = 2)]
        public decimal Sfxm { get; set; }
        public decimal Zjje { get; set; }
        public decimal Zfje { get; set; }
        public string Fphm { get; set; }
        public decimal? Jgid { get; set; }
        public  virtual GySfxm GySfxm { get; set; } 
    
        public virtual MsMzxx MsMzxx { get; set; }
    }
}

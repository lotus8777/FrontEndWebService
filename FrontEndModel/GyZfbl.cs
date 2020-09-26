using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace FE.Model.Hrp275
{

    [Table("GyZfbl")]
    public  class GyZfbl
    {
        [Key,Column(Order=1)]
        public decimal Sfxm { get; set; }
        [Key, Column(Order = 2)]
        public decimal Brxz { get; set; }
        public decimal Zfbl { get; set; }
        public decimal? Zyzfbl { get; set; }
    
        public virtual GyBrxz GyBrxz { get; set; }
        public virtual GySfxm GySfxm { get; set; }
    }
}

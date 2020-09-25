using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace FrontEndModel
{

    [Table("GyZfbl")]
    public  class GyZfbl
    {
        [Key,Column(Order=1)]
        public decimal sfxm { get; set; }
        [Key, Column(Order = 2)]
        public decimal brxz { get; set; }
        public decimal zfbl { get; set; }
        public decimal? ZYZFBL { get; set; }
    
        public virtual GyBrxz GyBrxz { get; set; }
        public virtual GySfxm gy_sfxm { get; set; }
    }
}

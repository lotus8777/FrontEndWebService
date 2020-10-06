using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("zy_jszf")]
    public  class ZyJszf
    {
        [Key,Column(Order = 1)]
        public decimal Zyh { get; set; }
        [Key, Column(Order = 2)]
        public decimal Jscs { get; set; }
        public string Zfgh { get; set; }
        public DateTime Zfrq { get; set; }
        public DateTime? Jzrq { get; set; }
        public DateTime? Hzrq { get; set; }
        public decimal? Jkda { get; set; }
        public decimal? Jgid { get; set; }
        public decimal? Zylb { get; set; }
    }
}

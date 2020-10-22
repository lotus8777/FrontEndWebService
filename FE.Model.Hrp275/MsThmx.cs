using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("ms_thmx")]
    public  class MsThmx
    {
        [Key]
        public decimal Sbxh { get; set; }
        public string Czgh { get; set; }
        public DateTime? Jzrq { get; set; }
        public decimal? Mzlb { get; set; }
        public DateTime? Hzrq { get; set; }
        public DateTime? Thrq { get; set; }
        public decimal? Cjbz { get; set; }
        public decimal? Txbz { get; set; }
        public decimal? Jgid { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 门诊分时段预约
    /// </summary>
    [Table("ms_fsdyyb")]
    public class MsFsdYy
    {
        [Key]
        public decimal Jlxh { get; set; }

        public DateTime Gzrq { get; set; }
        public string Ksdm { get; set; }
        public string Ysdm { get; set; }
        public decimal Zblb { get; set; }
        public decimal Jzxh { get; set; }
        public DateTime Jzsj { get; set; }
        public decimal? Yylb { get; set; }
        public decimal Ghpb { get; set; }
        public decimal? Brid { get; set; }
        public string Mzhm { get; set; }
        public string Brxm { get; set; }
        public string Lxdh { get; set; }
    }
}
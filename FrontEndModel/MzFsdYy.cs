using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    /// 门诊分时段预约
    /// </summary>
    [Table("ms_fsdyyb")]
    public class MzFsdYy
    {
        [Key]
        public decimal jlxh { get; set; }
        public DateTime gzrq { get; set; }
        public string ksdm { get; set; }
        public string ysdm { get; set; }
        public decimal zblb { get; set; }
        public decimal jzxh { get; set; }
        public DateTime jzsj { get; set; }
        public decimal? yylb { get; set; }
        public decimal ghpb { get; set; }
        public decimal? brid { get; set; }
        public string mzhm { get; set; }
        public string brxm { get; set; }
        public string lxdh { get; set; }
    }
}

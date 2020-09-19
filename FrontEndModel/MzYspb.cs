using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    [Table("ms_yspb")]
    public class MzYspb
    {
        [Key]
        [Column(Order = 0)]
        public DateTime gzrq { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ksdm { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ysdm { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal zblb { get; set; }

        public decimal ghxe { get; set; }
        public decimal ygrs { get; set; }
        public decimal yyrs { get; set; }
        public decimal jzxh { get; set; }
        public decimal yyxe { get; set; }
        public decimal tgbz { get; set; }
        public decimal? flag { get; set; }
        public decimal? ptyy { get; set; }
        public string hyxx { get; set; }
        public string yswz { get; set; }
        public decimal fsdpb { get; set; }
        public string jzfsxx { get; set; }
        public decimal? dqjzxh { get; set; }
        public string JSSJ { get; set; }
        public string KSSJ { get; set; }
        public string DDXX { get; set; }
        public decimal JGID { get; set; }
        public decimal? HYZS { get; set; }
        public decimal? HYMB { get; set; }
        public decimal? DHXE { get; set; }
        public decimal? ZZXE { get; set; }
        public decimal? ZJXE { get; set; }
        public virtual ICollection<MzFsdYy> MzFsdYyCollection { get; set; }
        public virtual MzGhks MzGhks { get; set; }
    }
}
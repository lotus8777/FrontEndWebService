using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    [Table("ms_yspb")]
    public class MsYspb
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Gzrq { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Ksdm { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Ysdm { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Zblb { get; set; }

        public decimal Ghxe { get; set; }
        public decimal Ygrs { get; set; }
        public decimal Yyrs { get; set; }
        public decimal Jzxh { get; set; }
        public decimal Yyxe { get; set; }
        public decimal Tgbz { get; set; }
        public decimal? Flag { get; set; }
        public decimal? Ptyy { get; set; }
        public string Hyxx { get; set; }
        public string Yswz { get; set; }
        public decimal Fsdpb { get; set; }
        public string Jzfsxx { get; set; }
        public decimal? Dqjzxh { get; set; }
        public string Jssj { get; set; }
        public string Kssj { get; set; }
        public string Ddxx { get; set; }
        public decimal Jgid { get; set; }
        public decimal? Hyzs { get; set; }
        public decimal? Hymb { get; set; }
        public decimal? Dhxe { get; set; }
        public decimal? Zzxe { get; set; }
        public decimal? Zjxe { get; set; }
        public virtual ICollection<MsFsdYy> MzFsdYyCollection { get; set; }
        public virtual MsGhks MsGhks { get; set; }
        [ForeignKey("Ysdm")]
        public virtual GyYgdm GyYgdm { get; set; }
    }
}
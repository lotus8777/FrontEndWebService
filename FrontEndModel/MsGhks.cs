using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 门诊-挂号科室
    /// </summary>
    [Table("ms_ghks")]
    public class MsGhks
    {
        [Key]
        public string Ksdm { get; set; }

        public string Ksmc { get; set; }
        public decimal Ghlb { get; set; }
        public string Pydm { get; set; }
        public string Wbdm { get; set; }
        public string Jxdm { get; set; }
        public string Qtdm { get; set; }
        public decimal Ghf { get; set; }
        public decimal Zlf { get; set; }
        public decimal Zjmz { get; set; }
        public decimal Ghxe { get; set; }
        public decimal Ygrs { get; set; }
        public decimal Yyrs { get; set; }
        public DateTime? Ghrq { get; set; }
        public decimal? Mzks { get; set; }
        public decimal Tjpb { get; set; }
        public decimal Tjf { get; set; }
        public decimal Mzlb { get; set; }
        public decimal? Jzxh { get; set; }
        public string Cjks { get; set; }
        public decimal? Cflb { get; set; }
        public decimal? Kswz { get; set; }
        public int? Zfpb { get; set; }
        public int? Zjlb { get; set; }
        public int? Yybz { get; set; }
        public int? Kyyts { get; set; }
        public string Zjsjap { get; set; }
        public decimal? Yyxe { get; set; }
        public DateTime? Yyghsx1 { get; set; }
        public DateTime? Yyghsx2 { get; set; }
        public string Ksms { get; set; }
        public string Dydm { get; set; }
        public string Nlxz { get; set; }
        public string Bglx { get; set; }
        public decimal? Scbz { get; set; }
        public decimal? Frmzbz { get; set; }
        public decimal? Xspb { get; set; }
        public decimal? Kfyypb { get; set; }
        public string Zswz { get; set; }
        public string Bzdm { get; set; }
        public decimal Jgid { get; set; }
        public string Ddxx { get; set; }
        public decimal? BglxYyh { get; set; }
        public decimal? ScbzYyh { get; set; }
        public string Lxdh { get; set; }
        public decimal? Jjrghf { get; set; }

        public virtual ICollection<MsGhmx> MsGhmx { get; set; }

        public virtual ICollection<MsYspb> MsYspb { get; set; }

        public virtual ICollection<MsYygh> MsYygh { get; set; }
    }
}
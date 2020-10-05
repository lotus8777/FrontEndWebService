using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("zy_cwsz")]
    public  class ZyCwsz
    {
        [Key]
        public string Brch { get; set; }
        public string Fjhm { get; set; }
        public decimal Cwks { get; set; }
        public decimal Ksdm { get; set; }
        public decimal Cwxb { get; set; }
        public decimal Cwfy { get; set; }
        public decimal Icu { get; set; }
        public decimal Jcpb { get; set; }
        public decimal? Zyh { get; set; }
        public decimal? Qtfy { get; set; }
        public decimal? Jgid { get; set; }
        public string Zrhs { get; set; }
        public string Gcys { get; set; }
        public decimal? Zdycw { get; set; }
        public decimal? Yewyh { get; set; }
    }
}

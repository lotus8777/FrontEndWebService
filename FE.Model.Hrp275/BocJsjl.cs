using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("boc_jsjl")]
    public  class BocJsjl
    {
        [Key]
        public decimal Jlxh { get; set; }
        public string Fphm { get; set; }
        public string Jzlsh { get; set; }
        public decimal Jzlx { get; set; }
        public decimal? Jslx { get; set; }
        public decimal Jyje { get; set; }
        public DateTime? Jyrq { get; set; }
        public string Pjh { get; set; }
        public string Pch { get; set; }
        public string Posname { get; set; }
        public string Czgh { get; set; }
        public string Zfposname { get; set; }
        public string Zfgh { get; set; }
        public DateTime? Zfrq { get; set; }
        public decimal? Zfpb { get; set; }
        public string Cardno { get; set; }
        public string Expr { get; set; }
        public string Sqhm { get; set; }
    }
}

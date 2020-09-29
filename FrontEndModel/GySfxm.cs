
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("gy_sfxm")]
    public class GySfxm
    {

        [Key]
        public decimal Sfxm { get; set; }
        public string Sfmc { get; set; }
        public string Mcsx { get; set; }
        public decimal Fyfl { get; set; }
        public decimal Mzsy { get; set; }
        public decimal Zysy { get; set; }
        public decimal Mzgb { get; set; }
        public decimal Zygb { get; set; }
        public decimal Fylb { get; set; }
        public string Pydm { get; set; }
        public decimal? Bxxm { get; set; }
        public string Kmbm { get; set; }
        public string Plsx { get; set; }
        public decimal? Ybgb { get; set; }
        public string Mzcjgb { get; set; }
        public string Zycjgb { get; set; }
        public decimal? Nbgb { get; set; }
        public decimal? Zyfpdy { get; set; }
        public decimal? Mzfpdy { get; set; }
        public string Zxgb { get; set; }
        public decimal? Lbdm { get; set; }
        public decimal? Wsj_Xmgb { get; set; }
        public decimal? Wsj_Xmgb_Zy { get; set; }
        public virtual ICollection<GyYlsf> GyYlsf { get; set; }
        public virtual ICollection<GyZfbl> GyZfbl { get; set; }
    }
}

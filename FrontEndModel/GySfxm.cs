
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{

    [Table("GySfxm")]
    public class GySfxm
    {


        [Key]
        public decimal sfxm { get; set; }
        public string sfmc { get; set; }
        public string mcsx { get; set; }
        public decimal fyfl { get; set; }
        public decimal mzsy { get; set; }
        public decimal zysy { get; set; }
        public decimal mzgb { get; set; }
        public decimal zygb { get; set; }
        public decimal fylb { get; set; }
        public string pydm { get; set; }
        public decimal? bxxm { get; set; }
        public string kmbm { get; set; }
        public string plsx { get; set; }
        public decimal? ybgb { get; set; }
        public string mzcjgb { get; set; }
        public string zycjgb { get; set; }
        public decimal? nbgb { get; set; }
        public decimal? zyfpdy { get; set; }
        public decimal? mzfpdy { get; set; }
        public string zxgb { get; set; }
        public decimal? LBDM { get; set; }
        public decimal? wsj_xmgb { get; set; }
        public decimal? wsj_xmgb_zy { get; set; }
        public virtual ICollection<GyYlsf> GyYlsf { get; set; }
        public virtual ICollection<GyZfbl> GyZfbl { get; set; }
    }
}

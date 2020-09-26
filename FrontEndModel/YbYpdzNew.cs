
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("yb_ypdz_new")]
    public class YbYpdzNew
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Ypxh { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Ypcd { get; set; }

        [StringLength(50)]
        public string Ybbm { get; set; }

        [StringLength(50)]
        public string Zwmc { get; set; }

        [StringLength(50)]
        public string Ywmc { get; set; }

        [StringLength(3)]
        public string Sflb { get; set; }

        [StringLength(3)]
        public string Ypzl { get; set; }

        [StringLength(3)]
        public string Cfyp { get; set; }

        [StringLength(3)]
        public string Ypdj { get; set; }

        [StringLength(3)]
        public string Splx { get; set; }

        [StringLength(3)]
        public string SplxSlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bjbz { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Kssj { get; set; }

        public DateTime? Zzsj { get; set; }

        [StringLength(10)]
        public string Zhxs { get; set; }

        [StringLength(3)]
        public string HzybSflb { get; set; }

        [StringLength(20)]
        public string Bzdw { get; set; }
    }
}
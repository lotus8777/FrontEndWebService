
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("yb_fydz")]
    public class YbFydz
    {
        [Key]
        [Column(Order = 0)]
        public decimal Fyxh { get; set; }

        [StringLength(50)]
        public string Ybbm { get; set; }

        [StringLength(50)]
        public string Xmmc { get; set; }

        [StringLength(3)]
        public string Sflb { get; set; }

        [StringLength(3)]
        public string Splx { get; set; }

        public decimal? Fylx { get; set; }

        [StringLength(3)]
        public string Fydj { get; set; }

        [StringLength(3)]
        public string SflbS { get; set; }

        [StringLength(3)]
        public string SplxS { get; set; }

        [StringLength(3)]
        public string FydjS { get; set; }

        [StringLength(3)]
        public string FydjLx { get; set; }

        [StringLength(3)]
        public string SflbLx { get; set; }

        [StringLength(3)]
        public string SplxLx { get; set; }

        [StringLength(3)]
        public string FydjTc { get; set; }

        [StringLength(3)]
        public string SflbTc { get; set; }

        [StringLength(3)]
        public string SplxTc { get; set; }

        [StringLength(3)]
        public string SplxSlx { get; set; }

        [StringLength(20)]
        public string Sjdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bjbz { get; set; }

        [StringLength(20)]
        public string SjdmLs { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Kssj { get; set; }

        public DateTime? Zzsj { get; set; }

        [StringLength(20)]
        public string Bzdw { get; set; }

        [StringLength(3)]
        public string HzybSflb { get; set; }
    }
}
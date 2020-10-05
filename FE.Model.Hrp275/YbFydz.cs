
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
        public string Sflb_S { get; set; }

        [StringLength(3)]
        public string Splx_S { get; set; }

        [StringLength(3)]
        public string Fydj_S { get; set; }

        [StringLength(3)]
        public string Fydj_Lx { get; set; }

        [StringLength(3)]
        public string Sflb_Lx { get; set; }

        [StringLength(3)]
        public string Splx_Lx { get; set; }

        [StringLength(3)]
        public string Fydj_Tc { get; set; }

        [StringLength(3)]
        public string Sflb_Tc { get; set; }

        [StringLength(3)]
        public string Splx_Tc { get; set; }

        [StringLength(3)]
        public string Splx_Slx { get; set; }

        [StringLength(20)]
        public string Sjdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bjbz { get; set; }

        [StringLength(20)]
        public string Sjdm_Ls { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Kssj { get; set; }

        public DateTime? Zzsj { get; set; }

        [StringLength(20)]
        public string Bzdw { get; set; }

        [StringLength(3)]
        public string Hzyb_Sflb { get; set; }
    }
}
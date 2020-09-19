namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class yb_fydz
    {
        [Key]
        [Column(Order = 0)]
        public decimal fyxh { get; set; }

        [StringLength(50)]
        public string ybbm { get; set; }

        [StringLength(50)]
        public string xmmc { get; set; }

        [StringLength(3)]
        public string sflb { get; set; }

        [StringLength(3)]
        public string splx { get; set; }

        public decimal? fylx { get; set; }

        [StringLength(3)]
        public string fydj { get; set; }

        [StringLength(3)]
        public string sflb_s { get; set; }

        [StringLength(3)]
        public string splx_s { get; set; }

        [StringLength(3)]
        public string fydj_s { get; set; }

        [StringLength(3)]
        public string fydj_lx { get; set; }

        [StringLength(3)]
        public string sflb_lx { get; set; }

        [StringLength(3)]
        public string splx_lx { get; set; }

        [StringLength(3)]
        public string fydj_tc { get; set; }

        [StringLength(3)]
        public string sflb_tc { get; set; }

        [StringLength(3)]
        public string splx_tc { get; set; }

        [StringLength(3)]
        public string splx_slx { get; set; }

        [StringLength(20)]
        public string sjdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bjbz { get; set; }

        [StringLength(20)]
        public string sjdm_ls { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime kssj { get; set; }

        public DateTime? zzsj { get; set; }

        [StringLength(20)]
        public string bzdw { get; set; }

        [StringLength(3)]
        public string hzyb_sflb { get; set; }
    }
}
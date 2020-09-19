namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class yb_ypdz_new
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal ypxh { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal ypcd { get; set; }

        [StringLength(50)]
        public string ybbm { get; set; }

        [StringLength(50)]
        public string zwmc { get; set; }

        [StringLength(50)]
        public string ywmc { get; set; }

        [StringLength(3)]
        public string sflb { get; set; }

        [StringLength(3)]
        public string ypzl { get; set; }

        [StringLength(3)]
        public string cfyp { get; set; }

        [StringLength(3)]
        public string ypdj { get; set; }

        [StringLength(3)]
        public string splx { get; set; }

        [StringLength(3)]
        public string splx_slx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bjbz { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime kssj { get; set; }

        public DateTime? zzsj { get; set; }

        [StringLength(10)]
        public string zhxs { get; set; }

        [StringLength(3)]
        public string hzyb_sflb { get; set; }

        [StringLength(20)]
        public string bzdw { get; set; }
    }
}
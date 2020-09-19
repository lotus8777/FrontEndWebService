namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class zy_ypyf
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal ypyf { get; set; }

        [StringLength(6)]
        public string pydm { get; set; }

        [StringLength(20)]
        public string xmmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xmlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fyxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yzpx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? KPDY { get; set; }
    }
}
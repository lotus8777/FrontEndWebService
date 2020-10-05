using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("zy_ypyf")]
    public class ZyYpyf
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Ypyf { get; set; }

        [StringLength(6)]
        public string Pydm { get; set; }

        [StringLength(20)]
        public string Xmmc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Xmlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fyxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yzpx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kpdy { get; set; }
    }
}
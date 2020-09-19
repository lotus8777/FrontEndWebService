namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class zy_ryzd
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal zyh { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal zdxh { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal zdlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zgqk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? txbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ZDLX { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("zy_ryzd")]
    public class ZyRyzd
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Zyh { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Zdxh { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Zdlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zgqk { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Txbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdlx { get; set; }
    }
}
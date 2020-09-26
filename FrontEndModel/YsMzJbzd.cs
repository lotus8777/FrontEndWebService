
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("ys_mz_jbzd")]
    public class YsMzJbzd
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Jlbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jzxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jbbh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jbzg { get; set; }

        [Required]
        [StringLength(10)]
        public string Ysdm { get; set; }

        public DateTime Zdsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxlb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Znxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fjbs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zzbj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Qzbz { get; set; }

        public DateTime? Qzsj { get; set; }

        [StringLength(50)]
        public string Ywbs { get; set; }

        [StringLength(60)]
        public string Fjmc { get; set; }

        [StringLength(2)]
        public string Jbzh { get; set; }

        [StringLength(255)]
        public string Jbmc { get; set; }

        [StringLength(100)]
        public string Bzxx { get; set; }

        [StringLength(255)]
        public string Mszd { get; set; }

        [StringLength(20)]
        public string Icd { get; set; }

        [StringLength(10)]
        public string Zfys { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }

        public DateTime? Zfsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Qmxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bkzt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdxh { get; set; }

        public virtual YsMzJzls YsMzJzls { get; set; }
    }
}
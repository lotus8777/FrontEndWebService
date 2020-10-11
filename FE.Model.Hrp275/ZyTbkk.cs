
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{

    [Table("zy_tbkk")]
    public class ZyTbkk
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int Jkxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zyh { get; set; }

        public DateTime Jkrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jkje { get; set; }

        [Column(TypeName = "numeric")]
        public int Jkfs { get; set; }

        [Required]
        [StringLength(8)]
        public string Sjhm { get; set; }

        [StringLength(20)]
        public string Zphm { get; set; }

        [Column(TypeName = "numeric")]
        public int Jscs { get; set; }

        [StringLength(10)]
        public string Czgh { get; set; }

        public DateTime? Jzrq { get; set; }

        public DateTime? Hzrq { get; set; }

        public DateTime? Zfrq { get; set; }

        [StringLength(10)]
        public string Zfgh { get; set; }

        [Column(TypeName = "numeric")]
        public int Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public int Zcpb { get; set; }

        [Column(TypeName = "numeric")]
        public int? Jgid { get; set; }

        [StringLength(20)]
        public string Czlx { get; set; }

        [Column(TypeName = "numeric")]
        public int? Brbq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brks { get; set; }

        [Column(TypeName = "numeric")]
        public int? Czbq { get; set; }

        [Column(TypeName = "numeric")]
        public int? Zylb { get; set; }
    }
}
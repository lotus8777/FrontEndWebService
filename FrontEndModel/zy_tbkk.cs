namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class zy_tbkk
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int jkxh { get; set; }

        [Column(TypeName = "numeric")]
        public int zyh { get; set; }

        public DateTime jkrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal jkje { get; set; }

        [Column(TypeName = "numeric")]
        public int jkfs { get; set; }

        [Required]
        [StringLength(8)]
        public string sjhm { get; set; }

        [StringLength(20)]
        public string zphm { get; set; }

        [Column(TypeName = "numeric")]
        public int jscs { get; set; }

        [StringLength(10)]
        public string czgh { get; set; }

        public DateTime? jzrq { get; set; }

        public DateTime? hzrq { get; set; }

        public DateTime? zfrq { get; set; }

        [StringLength(10)]
        public string zfgh { get; set; }

        [Column(TypeName = "numeric")]
        public int zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public int zcpb { get; set; }

        [Column(TypeName = "numeric")]
        public int? JGID { get; set; }

        [StringLength(20)]
        public string CZLX { get; set; }

        [Column(TypeName = "numeric")]
        public int? BRBQ { get; set; }

        [Column(TypeName = "numeric")]
        public int? BRKS { get; set; }

        [Column(TypeName = "numeric")]
        public int? CZBQ { get; set; }

        [Column(TypeName = "numeric")]
        public int? ZYLB { get; set; }
    }
}
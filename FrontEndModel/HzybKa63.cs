namespace FE.Model.Hrp275
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hzyb_ka63")]
    public class HzybKa63
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Bka900 { get; set; }

        [StringLength(200)]
        public string Bka901 { get; set; }

        [Column(TypeName = "text")]
        public string Bka902 { get; set; }

        [StringLength(50)]
        public string Bka903 { get; set; }

        [StringLength(3)]
        public string Bka904 { get; set; }

        [Column(TypeName = "text")]
        public string Aae013 { get; set; }

        [StringLength(3)]
        public string Aka065 { get; set; }

        [StringLength(3)]
        public string Aka063 { get; set; }

        [StringLength(3)]
        public string Bka905 { get; set; }

        [StringLength(3)]
        public string Bka906 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bka907 { get; set; }

        [StringLength(3)]
        public string Bka908 { get; set; }

        [StringLength(100)]
        public string Bka909 { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Aae030 { get; set; }

        public DateTime? Aae031 { get; set; }

        [StringLength(50)]
        public string Aka020 { get; set; }

        [StringLength(50)]
        public string Aka021 { get; set; }

        [StringLength(3)]
        public string Aka101 { get; set; }

        [StringLength(3)]
        public string Bka639 { get; set; }

        [StringLength(3)]
        public string Aae100 { get; set; }

        public DateTime? Aae036 { get; set; }

        [StringLength(3)]
        public string Bka925 { get; set; }

        [StringLength(3)]
        public string Ala011 { get; set; }

        [StringLength(3)]
        public string Ama011 { get; set; }

        [StringLength(200)]
        public string Bka921 { get; set; }

        [StringLength(200)]
        public string Bka922 { get; set; }

        [StringLength(100)]
        public string Aka074 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bka097 { get; set; }

        [StringLength(20)]
        public string Bka076 { get; set; }

        [StringLength(500)]
        public string Bka923 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bka098 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bka099 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bka924 { get; set; }

        [StringLength(3)]
        public string Bka613 { get; set; }

        [StringLength(3)]
        public string Aka022 { get; set; }

        [StringLength(3)]
        public string Bka253 { get; set; }

        [StringLength(3)]
        public string Bka218 { get; set; }

        [StringLength(3)]
        public string Bke091 { get; set; }
    }
}
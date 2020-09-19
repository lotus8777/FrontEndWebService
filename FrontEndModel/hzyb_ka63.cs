namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class hzyb_ka63
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bka900 { get; set; }

        [StringLength(200)]
        public string bka901 { get; set; }

        [Column(TypeName = "text")]
        public string bka902 { get; set; }

        [StringLength(50)]
        public string bka903 { get; set; }

        [StringLength(3)]
        public string bka904 { get; set; }

        [Column(TypeName = "text")]
        public string aae013 { get; set; }

        [StringLength(3)]
        public string aka065 { get; set; }

        [StringLength(3)]
        public string aka063 { get; set; }

        [StringLength(3)]
        public string bka905 { get; set; }

        [StringLength(3)]
        public string bka906 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bka907 { get; set; }

        [StringLength(3)]
        public string bka908 { get; set; }

        [StringLength(100)]
        public string bka909 { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime aae030 { get; set; }

        public DateTime? aae031 { get; set; }

        [StringLength(50)]
        public string aka020 { get; set; }

        [StringLength(50)]
        public string aka021 { get; set; }

        [StringLength(3)]
        public string aka101 { get; set; }

        [StringLength(3)]
        public string bka639 { get; set; }

        [StringLength(3)]
        public string aae100 { get; set; }

        public DateTime? aae036 { get; set; }

        [StringLength(3)]
        public string bka925 { get; set; }

        [StringLength(3)]
        public string ala011 { get; set; }

        [StringLength(3)]
        public string ama011 { get; set; }

        [StringLength(200)]
        public string bka921 { get; set; }

        [StringLength(200)]
        public string bka922 { get; set; }

        [StringLength(100)]
        public string aka074 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bka097 { get; set; }

        [StringLength(20)]
        public string bka076 { get; set; }

        [StringLength(500)]
        public string bka923 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bka098 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bka099 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bka924 { get; set; }

        [StringLength(3)]
        public string bka613 { get; set; }

        [StringLength(3)]
        public string aka022 { get; set; }

        [StringLength(3)]
        public string bka253 { get; set; }

        [StringLength(3)]
        public string bka218 { get; set; }

        [StringLength(3)]
        public string bke091 { get; set; }
    }
}
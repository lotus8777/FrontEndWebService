namespace FrontEndModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class zy_fymx
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal jlxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zyh { get; set; }

        public DateTime fyrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fyxh { get; set; }

        [StringLength(60)]
        public string fymc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ypcd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fysl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fydj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zjje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfje { get; set; }

        [StringLength(10)]
        public string ysgh { get; set; }

        [StringLength(10)]
        public string srgh { get; set; }

        [StringLength(10)]
        public string qrgh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fybq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fyks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zxks { get; set; }

        public DateTime jfrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal xmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal YPLX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fyxm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal jscs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfbl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yzxh { get; set; }

        public DateTime? hzrq { get; set; }

        [StringLength(8)]
        public string yjrq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zlje { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? zlxz { get; set; }

        public decimal? scbz_yh { get; set; }

        public decimal? cjbz { get; set; }

        [StringLength(18)]
        public string spxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? scbz { get; set; }

        public decimal? yjcs { get; set; }

        public decimal? spbh { get; set; }

        public decimal? jscs_jcy { get; set; }

        [StringLength(20)]
        public string wenjianbm { get; set; }

        [StringLength(20)]
        public string hismac { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nbsc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ckdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cksl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bzxz { get; set; }

        [StringLength(3)]
        public string sflb { get; set; }

        [StringLength(3)]
        public string xmdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tfxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? yefbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cfts { get; set; }

        [StringLength(200)]
        public string tsxx { get; set; }

        [StringLength(50)]
        public string ybbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YBZFPB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? wybz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }

        [StringLength(100)]
        public string ZTMC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JHH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TFGL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YTSL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DZBL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YEPB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? jmbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? YB_SFKB { get; set; }
    }
}
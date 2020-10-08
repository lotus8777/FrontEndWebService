using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    using System;
    using System.Collections.Generic;
    [Table("zy_bqyz")]
    public  class ZyBqyz
    {
        [Key]
        public decimal Jlxh { get; set; }
        public decimal Zyh { get; set; }
        public string Yzmc { get; set; }
        public decimal Ypxh { get; set; }
        public decimal Ypcd { get; set; }
        public decimal Xmlx { get; set; }
        public decimal Yplx { get; set; }
        public decimal Mrcs { get; set; }
        public decimal Ycjl { get; set; }
        public decimal Ycsl { get; set; }
        public decimal Mzcs { get; set; }
        public DateTime? Kssj { get; set; }
        public DateTime? Qrsj { get; set; }
        public DateTime? Tzsj { get; set; }
        public decimal Ypdj { get; set; }
        public decimal Ypyf { get; set; }
        public string Ysgh { get; set; }
        public string Tzys { get; set; }
        public string Czgh { get; set; }
        public string Fhgh { get; set; }
        public decimal Sybz { get; set; }
        public decimal? Srks { get; set; }
        public decimal Zfpb { get; set; }
        public decimal Yjzx { get; set; }
        public decimal Yjxh { get; set; }
        public string Tjhm { get; set; }
        public decimal? Zxks { get; set; }
        public DateTime? Aprq { get; set; }
        public decimal Yzzh { get; set; }
        public string Sypc { get; set; }
        public decimal Fysx { get; set; }
        public decimal Yepb { get; set; }
        public decimal Yfsb { get; set; }
        public decimal Lsyz { get; set; }
        public decimal Lsbz { get; set; }
        public decimal Yzpb { get; set; }
        public decimal Jfbz { get; set; }
        public string Bzxx { get; set; }
        public string Hyxm { get; set; }
        public decimal? Fyfs { get; set; }
        public decimal Tpn { get; set; }
        public decimal Ysbz { get; set; }
        public decimal? Ystj { get; set; }
        public DateTime? Fytx { get; set; }
        public decimal? Yzpx { get; set; }
        public decimal? Sqwh { get; set; }
        public decimal? Ysyzbh { get; set; }
        public decimal? Sqid { get; set; }
        public decimal? Zfbz { get; set; }
        public decimal? Spbh { get; set; }
        public decimal? Sl1 { get; set; }
        public decimal? Sl2 { get; set; }
        public decimal? Sl3 { get; set; }
        public decimal? Dybz { get; set; }
        public DateTime? Tjsj { get; set; }
        public DateTime? Dysj { get; set; }
        public string Jldw { get; set; }
        public decimal? Jybz { get; set; }
        public decimal? Jytcxh { get; set; }
        public string Xml { get; set; }
        public string Sqdmc { get; set; }
        public decimal? Ssbh { get; set; }
        public decimal? Yewyh { get; set; }
        public decimal? Jzid { get; set; }
        public decimal? Srcs { get; set; }
        public string Brch { get; set; }
        public decimal? Yyts { get; set; }
        public string Yfgg { get; set; }
        public string Yfdw { get; set; }
        public decimal? Yfbz { get; set; }
        public decimal? Yqsy { get; set; }
        public decimal? Yfyy { get; set; }
        public string Yfyyyy { get; set; }
        public decimal? Sfsj { get; set; }
        public decimal? Ysyzzh { get; set; }
        public decimal? Brbq { get; set; }
        public decimal? Brks { get; set; }
        public decimal? Cfts { get; set; }
        public string Hszxgh { get; set; }
        public string Pzfs { get; set; }
        public string Dyr { get; set; }
        public string Ztmc { get; set; }
        public decimal? Jgid { get; set; }
        public string Psfh { get; set; }
        public string Psgh { get; set; }
        public string Sfyj { get; set; }
        public string Sfgh { get; set; }
        public string Tzfhr { get; set; }
        public string Yzzxsj { get; set; }
        public string Pzpc { get; set; }
        public DateTime? Zhzx { get; set; }
        public DateTime? Pssj { get; set; }
        public DateTime? Fhsj { get; set; }
        public DateTime? Tzfhsj { get; set; }
        public DateTime? Jhrq { get; set; }
        public DateTime? Hszxsj { get; set; }
        public decimal? Nwarn { get; set; }
        public decimal? Yzshcs { get; set; }
        public decimal? Zlfy { get; set; }
        public decimal? Zlxz { get; set; }
        public decimal? Jszq { get; set; }
        public decimal? Jcxm { get; set; }
        public decimal? Yyps { get; set; }
        public decimal? Pspb { get; set; }
        public decimal? Tzfhbz { get; set; }
        public decimal? Fhbz { get; set; }
        public decimal? Sfjg { get; set; }
        public decimal? Psjg { get; set; }
        public decimal? Psgl { get; set; }
        public decimal? Kcxbz { get; set; }
        public string Erzyh { get; set; }
        public decimal? Mzdjbz { get; set; }
        public decimal? Jysj { get; set; }
        public decimal? Scbz_Yh { get; set; }
        public decimal? Yh_Scbz { get; set; }
        public decimal? Scbz { get; set; }
        public decimal? Jmbz { get; set; }
        public decimal? Scylcs { get; set; }
        public decimal? Yldfbz { get; set; }
        public decimal? Yefbz { get; set; }
        public decimal? Ybzfpb { get; set; }
        public decimal? Yb_Sfkb { get; set; }
        [ForeignKey("Srks")]
        public virtual GyKsdm GyKsdm { get; set; }
        [ForeignKey("Ysgh")]
        public virtual GyYgdm GyYgdm { get; set; }
        [ForeignKey("Ypyf")]
        public virtual ZyYpyf ZyYpyf { get; set; }
        [ForeignKey("Sypc")]
        public virtual GySypc GySypc { get; set; }
    }
}

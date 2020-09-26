using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FE.Model.Hrp275
{
  [Table("yk_typk")]

    public class YkTypk
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Ypxh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Xtsb { get; set; }

        [Required]
        [StringLength(40)]
        public string Ypmc { get; set; }

        [StringLength(20)]
        public string Ypgg { get; set; }

        [StringLength(20)]
        public string Yfgg { get; set; }

        [StringLength(20)]
        public string Bfgg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypsx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Tsyp { get; set; }

        [StringLength(4)]
        public string Ypdw { get; set; }

        [StringLength(4)]
        public string Zxdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zxbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yfbz { get; set; }

        [StringLength(4)]
        public string Yfdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Bfbz { get; set; }

        [StringLength(4)]
        public string Bfdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zssf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Pspb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ylxz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Fyfs { get; set; }

        [StringLength(8)]
        public string Pydm { get; set; }

        [StringLength(8)]
        public string Wbdm { get; set; }

        [StringLength(8)]
        public string Jxdm { get; set; }

        [StringLength(8)]
        public string Qtdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Gcsl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Dcsl { get; set; }

        [StringLength(20)]
        public string Ypbh { get; set; }

        [StringLength(250)]
        public string Mess { get; set; }

        public int Djjb { get; set; }

        [StringLength(16)]
        public string Kwbm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ypxq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gyff { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Type { get; set; }

        [StringLength(16)]
        public string Ypdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypdc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yfdc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Bfdc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ykzf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Yfzf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Bfzf { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zjpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jzyy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Ypjl { get; set; }

        [StringLength(8)]
        public string Jldw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Zblb { get; set; }

        [Required]
        [StringLength(1)]
        public string Abc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yfgc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bfgc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Qzcl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Tpn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxcd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ksbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ycyl { get; set; }

        [StringLength(30)]
        public string YbbmYh { get; set; }

        public decimal? YbflYh { get; set; }

        public decimal? ShbzYh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxjl { get; set; }

        [StringLength(6)]
        public string Jldw1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zxbz1 { get; set; }

        [StringLength(6)]
        public string Zxdw1 { get; set; }

        public decimal? Mzxl { get; set; }

        public decimal? Zyxl { get; set; }

        public decimal? Yyxz { get; set; }

        public decimal? MzxlLx { get; set; }

        [StringLength(20)]
        public string Nbbm { get; set; }

        [StringLength(6)]
        public string YpyfYs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MrjlYs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybfl { get; set; }

        [StringLength(2)]
        public string Lbdm { get; set; }

        [StringLength(15)]
        public string Ybdm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kfdwjl { get; set; }

        [StringLength(4)]
        public string Kfdw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zbpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zbtjbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yfjjbz { get; set; }

        [StringLength(100)]
        public string Yfjjmx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ylbxxl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kssdj { get; set; }

        public int? Nbfl { get; set; }

        [StringLength(255)]
        public string Ybxlsm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Jbywpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Szbjypb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yplb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cqfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Chfy { get; set; }

        [StringLength(4)]
        public string Mrxl { get; set; }

        [StringLength(40)]
        public string Qbzf { get; set; }

        [StringLength(6)]
        public string Pcbm { get; set; }

        [StringLength(255)]
        public string Hzxz { get; set; }

        [StringLength(255)]
        public string Ypxz { get; set; }

        [StringLength(100)]
        public string Tsjd { get; set; }

        [StringLength(20)]
        public string Atcm { get; set; }

        [StringLength(80)]
        public string Ywmc { get; set; }

        [StringLength(80)]
        public string Tymc { get; set; }

        [StringLength(30)]
        public string Yybz { get; set; }

        [StringLength(40)]
        public string Dwqc { get; set; }

        [StringLength(80)]
        public string Ggqc { get; set; }

        public DateTime? Xzsj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjjb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gwyp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zclc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdlc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zlfy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kssfl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjyfyy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yjtxfs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjspbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Dddz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tsyy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ksdj { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Zdjl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ycjl { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cfyp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ypzc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Bxlc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ydysy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jbywbz { get; set; }

        [StringLength(150)]
        public string Ypqc { get; set; }

        [StringLength(8)]
        public string Ddddw { get; set; }

        [StringLength(20)]
        public string NbbmLs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hlyybfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hlyyyfbz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Pszlxmid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jmlx { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hlyycblsdpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hlyybjfpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Yebz { get; set; }

        public decimal? Kjdddggmz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjywpb { get; set; }

        public decimal? Kjdddgg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Kjdddz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gwyppb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybxlfw { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybxl2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ybxl1 { get; set; }
    }
}
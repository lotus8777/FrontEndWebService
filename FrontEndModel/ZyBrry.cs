using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    ///   Defines the <see cref="ZyBrry" />
    /// </summary>
    [Table("zy_brry")]
    public class ZyBrry
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int ZYH { get; set; }

        /// <summary>
        ///   Gets or sets the ZYHM
        /// </summary>
        [Required]
        [StringLength(8)]
        public string ZYHM { get; set; }

        /// <summary>
        ///   Gets or sets the BAHM
        /// </summary>
        [StringLength(8)]
        public string BAHM { get; set; }

        /// <summary>
        ///   Gets or sets the MZHM
        /// </summary>
        [StringLength(12)]
        public string MZHM { get; set; }

        /// <summary>
        ///   Gets or sets the BRXZ
        /// </summary>
        [Column(TypeName = "numeric")]
        public int BRXZ { get; set; }

        /// <summary>
        ///   Gets or sets the GFZH
        /// </summary>
        [StringLength(20)]
        public string GFZH { get; set; }

        /// <summary>
        ///   Gets or sets the BRXM
        /// </summary>
        [Required]
        [StringLength(40)]
        public string BRXM { get; set; }

        /// <summary>
        ///   Gets or sets the BRXB
        /// </summary>
        [Column(TypeName = "numeric")]
        public int BRXB { get; set; }

        /// <summary>
        ///   Gets or sets the CSNY
        /// </summary>
        public DateTime? CSNY { get; set; }

        /// <summary>
        ///   Gets or sets the SFZH
        /// </summary>
        [StringLength(20)]
        public string SFZH { get; set; }

        /// <summary>
        ///   Gets or sets the HYZK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? HYZK { get; set; }

        /// <summary>
        ///   Gets or sets the ZYDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? ZYDM { get; set; }

        /// <summary>
        ///   Gets or sets the SFDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? SFDM { get; set; }

        /// <summary>
        ///   Gets or sets the JGDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? JGDM { get; set; }

        /// <summary>
        ///   Gets or sets the MZDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? MZDM { get; set; }

        /// <summary>
        ///   Gets or sets the GJDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? GJDM { get; set; }

        /// <summary>
        ///   Gets or sets the DWBH
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? DWBH { get; set; }

        /// <summary>
        ///   Gets or sets the GZDW
        /// </summary>
        [StringLength(40)]
        public string GZDW { get; set; }

        /// <summary>
        ///   Gets or sets the DWDH
        /// </summary>
        [StringLength(16)]
        public string DWDH { get; set; }

        /// <summary>
        ///   Gets or sets the DWYB
        /// </summary>
        [StringLength(6)]
        public string DWYB { get; set; }

        /// <summary>
        ///   Gets or sets the HKDZ
        /// </summary>
        [StringLength(40)]
        public string HKDZ { get; set; }

        /// <summary>
        ///   Gets or sets the HKYB
        /// </summary>
        [StringLength(6)]
        public string HKYB { get; set; }

        /// <summary>
        ///   Gets or sets the LXRM
        /// </summary>
        [StringLength(10)]
        public string LXRM { get; set; }

        /// <summary>
        ///   Gets or sets the LXGX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? LXGX { get; set; }

        /// <summary>
        ///   Gets or sets the LXDZ
        /// </summary>
        [StringLength(40)]
        public string LXDZ { get; set; }

        /// <summary>
        ///   Gets or sets the LXDH
        /// </summary>
        [StringLength(16)]
        public string LXDH { get; set; }

        /// <summary>
        ///   Gets or sets the PZHM
        /// </summary>
        [StringLength(10)]
        public string PZHM { get; set; }

        /// <summary>
        ///   Gets or sets the SBHM
        /// </summary>
        [StringLength(20)]
        public string SBHM { get; set; }

        /// <summary>
        ///   Gets or sets the DBRM
        /// </summary>
        [StringLength(10)]
        public string DBRM { get; set; }

        /// <summary>
        ///   Gets or sets the DBGX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? DBGX { get; set; }

        /// <summary>
        ///   Gets or sets the ZZTX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? ZZTX { get; set; }

        /// <summary>
        ///   Gets or sets the DBBZ
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? DBBZ { get; set; }

        /// <summary>
        ///   Gets or sets the BRKS
        /// </summary>
        [Column(TypeName = "numeric")]
        public int BRKS { get; set; }

        /// <summary>
        ///   Gets or sets the BRBQ
        /// </summary>
        [Column(TypeName = "numeric")]
        public int? BRBQ { get; set; }

        /// <summary>
        ///   Gets or sets the BRCH
        /// </summary>
        [StringLength(6)]
        public string BRCH { get; set; }

        /// <summary>
        ///   Gets or sets the DJRQ
        /// </summary>
        public DateTime DJRQ { get; set; }

        /// <summary>
        ///   Gets or sets the RYRQ
        /// </summary>
        public DateTime RYRQ { get; set; }

        /// <summary>
        ///   Gets or sets the CYRQ
        /// </summary>
        public DateTime? CYRQ { get; set; }

        /// <summary>
        ///   Gets or sets the CYPB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal CYPB { get; set; }

        /// <summary>
        ///   Gets or sets the CYFS
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? CYFS { get; set; }

        /// <summary>
        ///   Gets or sets the CZGH
        /// </summary>
        [StringLength(10)]
        public string CZGH { get; set; }

        /// <summary>
        ///   Gets or sets the RYQK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? RYQK { get; set; }

        /// <summary>
        ///   Gets or sets the BRQK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? BRQK { get; set; }

        /// <summary>
        ///   Gets or sets the HLJB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? HLJB { get; set; }

        /// <summary>
        ///   Gets or sets the YSDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? YSDM { get; set; }

        /// <summary>
        ///   Gets or sets the BRXX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? BRXX { get; set; }

        /// <summary>
        ///   Gets or sets the hzks
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? hzks { get; set; }

        /// <summary>
        ///   Gets or sets the jcks
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? jcks { get; set; }

        /// <summary>
        ///   Gets or sets the MZYS
        /// </summary>
        [StringLength(10)]
        public string MZYS { get; set; }

        /// <summary>
        ///   Gets or sets the ZYYS
        /// </summary>
        [StringLength(10)]
        public string ZYYS { get; set; }

        /// <summary>
        ///   Gets or sets the ZSYS
        /// </summary>
        [StringLength(10)]
        public string ZSYS { get; set; }

        /// <summary>
        ///   Gets or sets the ZZYS
        /// </summary>
        [StringLength(10)]
        public string ZZYS { get; set; }

        /// <summary>
        ///   Gets or sets the qzrq
        /// </summary>
        public DateTime? qzrq { get; set; }

        /// <summary>
        ///   Gets or sets the ksrq
        /// </summary>
        public DateTime? ksrq { get; set; }

        /// <summary>
        ///   Gets or sets the jsrq
        /// </summary>
        public DateTime? jsrq { get; set; }

        /// <summary>
        ///   Gets or sets the jscs
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal jscs { get; set; }

        /// <summary>
        ///   Gets or sets the jzrq
        /// </summary>
        public DateTime? jzrq { get; set; }

        /// <summary>
        ///   Gets or sets the hzrq
        /// </summary>
        public DateTime? hzrq { get; set; }

        /// <summary>
        ///   Gets or sets the XGPB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal XGPB { get; set; }

        /// <summary>
        ///   Gets or sets the bapb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal bapb { get; set; }

        /// <summary>
        ///   Gets or sets the brgl
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? brgl { get; set; }

        /// <summary>
        ///   Gets or sets the brkl
        /// </summary>
        [StringLength(6)]
        public string brkl { get; set; }

        /// <summary>
        ///   Gets or sets the bz
        /// </summary>
        [StringLength(250)]
        public string bz { get; set; }

        /// <summary>
        ///   Gets or sets the brqm
        /// </summary>
        [StringLength(32)]
        public string brqm { get; set; }

        /// <summary>
        ///   Gets or sets the jtdh
        /// </summary>
        [StringLength(16)]
        public string jtdh { get; set; }

        /// <summary>
        ///   Gets or sets the ybkh
        /// </summary>
        [StringLength(50)]
        public string ybkh { get; set; }

        /// <summary>
        ///   Gets or sets the jzkh
        /// </summary>
        [StringLength(40)]
        public string jzkh { get; set; }

        /// <summary>
        ///   Gets or sets the SZYS
        /// </summary>
        [StringLength(10)]
        public string SZYS { get; set; }

        /// <summary>
        ///   Gets or sets the zlxz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? zlxz { get; set; }

        /// <summary>
        ///   Gets or sets the spje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? spje { get; set; }

        /// <summary>
        ///   Gets or sets the sjzy
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? sjzy { get; set; }

        /// <summary>
        ///   Gets or sets the djbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal djbz { get; set; }

        /// <summary>
        ///   Gets or sets the djid
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal djid { get; set; }

        /// <summary>
        ///   Gets or sets the djje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal djje { get; set; }

        /// <summary>
        ///   Gets or sets the ysjs
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? ysjs { get; set; }

        /// <summary>
        ///   Gets or sets the zkzt
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? zkzt { get; set; }

        /// <summary>
        ///   Gets or sets the grbh_yh
        /// </summary>
        [StringLength(30)]
        public string grbh_yh { get; set; }

        /// <summary>
        ///   Gets or sets the ybkh_yh
        /// </summary>
        [StringLength(30)]
        public string ybkh_yh { get; set; }

        /// <summary>
        ///   Gets or sets the rylb_yh
        /// </summary>
        public decimal? rylb_yh { get; set; }

        /// <summary>
        ///   Gets or sets the lbmc_yh
        /// </summary>
        [StringLength(30)]
        public string lbmc_yh { get; set; }

        /// <summary>
        ///   Gets or sets the knxx_yh
        /// </summary>
        [StringLength(30)]
        public string knxx_yh { get; set; }

        /// <summary>
        ///   Gets or sets the ywxlh_yh
        /// </summary>
        [StringLength(30)]
        public string ywxlh_yh { get; set; }

        /// <summary>
        ///   Gets or sets the zycs_yh
        /// </summary>
        public decimal? zycs_yh { get; set; }

        /// <summary>
        ///   Gets or sets the bargainingid
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? bargainingid { get; set; }

        /// <summary>
        ///   Gets or sets the yylsh
        /// </summary>
        [StringLength(40)]
        public string yylsh { get; set; }

        /// <summary>
        ///   Gets or sets the ycts
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? ycts { get; set; }

        /// <summary>
        ///   Gets or sets the khmm
        /// </summary>
        [StringLength(10)]
        public string khmm { get; set; }

        /// <summary>
        ///   Gets or sets the grbh
        /// </summary>
        [StringLength(20)]
        public string grbh { get; set; }

        /// <summary>
        ///   Gets or sets the bzbh
        /// </summary>
        [StringLength(10)]
        public string bzbh { get; set; }

        /// <summary>
        ///   Gets or sets the qgyz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qgyz { get; set; }

        /// <summary>
        ///   Gets or sets the dylb
        /// </summary>
        [StringLength(4)]
        public string dylb { get; set; }

        /// <summary>
        ///   Gets or sets the icmw
        /// </summary>
        [StringLength(500)]
        public string icmw { get; set; }

        /// <summary>
        ///   Gets or sets the rylx
        /// </summary>
        public decimal? rylx { get; set; }

        /// <summary>
        ///   Gets or sets the cjbz_ry
        /// </summary>
        public decimal? cjbz_ry { get; set; }

        /// <summary>
        ///   Gets or sets the smkwkh
        /// </summary>
        [StringLength(20)]
        public string smkwkh { get; set; }

        /// <summary>
        ///   Gets or sets the kzhm
        /// </summary>
        [StringLength(30)]
        public string kzhm { get; set; }

        /// <summary>
        ///   Gets or sets the jsdh
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? jsdh { get; set; }

        /// <summary>
        ///   Gets or sets the scjl
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? scjl { get; set; }

        /// <summary>
        ///   Gets or sets the gwyjb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? gwyjb { get; set; }

        /// <summary>
        ///   Gets or sets the icd9
        /// </summary>
        [StringLength(10)]
        public string icd9 { get; set; }

        /// <summary>
        ///   Gets or sets the zxlsh
        /// </summary>
        [StringLength(30)]
        public string zxlsh { get; set; }

        /// <summary>
        ///   Gets or sets the ylrylb
        /// </summary>
        [StringLength(10)]
        public string ylrylb { get; set; }

        /// <summary>
        ///   Gets or sets the fjrylb
        /// </summary>
        [StringLength(10)]
        public string fjrylb { get; set; }

        /// <summary>
        ///   Gets or sets the icxx
        /// </summary>
        [Column(TypeName = "text")]
        public string icxx { get; set; }

        /// <summary>
        ///   Gets or sets the ickh
        /// </summary>
        [StringLength(30)]
        public string ickh { get; set; }

        /// <summary>
        ///   Gets or sets the dnzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? dnzhye { get; set; }

        /// <summary>
        ///   Gets or sets the lnzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? lnzhye { get; set; }

        /// <summary>
        ///   Gets or sets the scxh
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? scxh { get; set; }

        /// <summary>
        ///   Gets or sets the ryxz
        /// </summary>
        [StringLength(2)]
        public string ryxz { get; set; }

        /// <summary>
        ///   Gets or sets the cbxz
        /// </summary>
        [StringLength(8)]
        public string cbxz { get; set; }

        /// <summary>
        ///   Gets or sets the scbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? scbz { get; set; }

        /// <summary>
        ///   Gets or sets the tsbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? tsbz { get; set; }

        /// <summary>
        ///   Gets or sets the cayldh
        /// </summary>
        [StringLength(20)]
        public string cayldh { get; set; }

        /// <summary>
        ///   Gets or sets the yldh
        /// </summary>
        [StringLength(20)]
        public string yldh { get; set; }

        /// <summary>
        ///   Gets or sets the zylx
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? zylx { get; set; }

        /// <summary>
        ///   Gets or sets the tsbzbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? tsbzbz { get; set; }

        /// <summary>
        ///   Gets or sets the cabzlx
        /// </summary>
        [StringLength(50)]
        public string cabzlx { get; set; }

        /// <summary>
        ///   Gets or sets the cajzlx
        /// </summary>
        [StringLength(50)]
        public string cajzlx { get; set; }

        /// <summary>
        ///   Gets or sets the cahmlx
        /// </summary>
        [StringLength(50)]
        public string cahmlx { get; set; }

        /// <summary>
        ///   Gets or sets the caxsbz
        /// </summary>
        [StringLength(2)]
        public string caxsbz { get; set; }

        /// <summary>
        ///   Gets or sets the cazh
        /// </summary>
        [StringLength(30)]
        public string cazh { get; set; }

        /// <summary>
        ///   Gets or sets the cazjlx
        /// </summary>
        [StringLength(50)]
        public string cazjlx { get; set; }

        /// <summary>
        ///   Gets or sets the cadxbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? cadxbz { get; set; }

        /// <summary>
        ///   Gets or sets the bxlx
        /// </summary>
        [StringLength(20)]
        public string bxlx { get; set; }

        /// <summary>
        ///   Gets or sets the grzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? grzhye { get; set; }

        /// <summary>
        ///   Gets or sets the rylxmc
        /// </summary>
        [StringLength(30)]
        public string rylxmc { get; set; }

        /// <summary>
        ///   Gets or sets the xzqydm
        /// </summary>
        [StringLength(6)]
        public string xzqydm { get; set; }

        /// <summary>
        ///   Gets or sets the yjsrq
        /// </summary>
        public DateTime? yjsrq { get; set; }

        /// <summary>
        ///   Gets or sets the qfsdbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qfsdbz { get; set; }

        /// <summary>
        ///   Gets or sets the zjje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? zjje { get; set; }

        /// <summary>
        ///   Gets or sets the jfje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? jfje { get; set; }

        /// <summary>
        ///   Gets or sets the jsje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? jsje { get; set; }

        /// <summary>
        ///   Gets or sets the qfje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qfje { get; set; }

        /// <summary>
        ///   Gets or sets the qfdbbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qfdbbz { get; set; }

        /// <summary>
        ///   Gets or sets the qfdbyy
        /// </summary>
        [StringLength(100)]
        public string qfdbyy { get; set; }

        /// <summary>
        ///   Gets or sets the yllb
        /// </summary>
        [StringLength(3)]
        public string yllb { get; set; }

        /// <summary>
        ///   Gets or sets the cbd_xzdm
        /// </summary>
        [StringLength(6)]
        public string cbd_xzdm { get; set; }

        /// <summary>
        ///   Gets or sets the blbbh
        /// </summary>
        [StringLength(20)]
        public string blbbh { get; set; }

        /// <summary>
        ///   Gets or sets the qypb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qypb { get; set; }

        /// <summary>
        ///   Gets or sets the qybr
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? qybr { get; set; }

        /// <summary>
        ///   Gets or sets the dasc
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? dasc { get; set; }

        /// <summary>
        ///   Gets or sets the actnumber
        /// </summary>
        [StringLength(60)]
        public string actnumber { get; set; }

        /// <summary>
        ///   Gets or sets the url
        /// </summary>
        [StringLength(255)]
        public string url { get; set; }

        /// <summary>
        ///   Gets or sets the bllx
        /// </summary>
        [StringLength(3)]
        public string bllx { get; set; }

        /// <summary>
        ///   Gets or sets the jzbh
        /// </summary>
        [StringLength(20)]
        public string jzbh { get; set; }

        /// <summary>
        ///   Gets or sets the dbz
        /// </summary>
        [StringLength(3)]
        public string dbz { get; set; }

        /// <summary>
        ///   Gets or sets the dyzt
        /// </summary>
        [StringLength(10)]
        public string dyzt { get; set; }

        /// <summary>
        ///   Gets or sets the cardno
        /// </summary>
        [StringLength(40)]
        public string cardno { get; set; }

        /// <summary>
        ///   Gets or sets the jtbc
        /// </summary>
        [StringLength(20)]
        public string jtbc { get; set; }

        /// <summary>
        ///   Gets or sets the bjbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? bjbz { get; set; }

        /// <summary>
        ///   Gets or sets the bjdj
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? bjdj { get; set; }

        /// <summary>
        ///   Gets or sets the yepb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? yepb { get; set; }

        /// <summary>
        ///   Gets or sets the zszpb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? zszpb { get; set; }

        /// <summary>
        ///   Gets or sets the rylb
        /// </summary>
        [StringLength(10)]
        public string rylb { get; set; }

        /// <summary>
        ///   Gets or sets the ygys
        /// </summary>
        [StringLength(10)]
        public string ygys { get; set; }

        /// <summary>
        ///   Gets or sets the brlx
        /// </summary>
        public decimal brlx { get; set; }

        [Column(TypeName = "numeric")]
        public int YDJSBZ { get; set; }

        [ForeignKey("BRKS")]
        public virtual GyKsdm KsBrks { get; set; }

        public virtual GyBrxz GyBrxz { get; set; }
        public virtual IList<zy_tbkk> Jkmx { get; set; }
        public virtual IList<zy_fymx> Fymx { get; set; }
    }
}
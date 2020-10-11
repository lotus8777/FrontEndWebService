using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    ///   Defines the <see cref="ZyBrry" />
    /// </summary>
    [Table("zy_brry")]
    public class ZyBrry
    {
        [Key]
        public decimal Zyh { get; set; }

        /// <summary>
        ///   Gets or sets the ZYHM
        /// </summary>
        [Required]
        [StringLength(8)]
        public string Zyhm { get; set; }

        /// <summary>
        ///   Gets or sets the BAHM
        /// </summary>
        [StringLength(8)]
        public string Bahm { get; set; }

        /// <summary>
        ///   Gets or sets the MZHM
        /// </summary>
        [StringLength(12)]
        public string Mzhm { get; set; }

        /// <summary>
        ///   Gets or sets the BRXZ
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Brxz { get; set; }

        /// <summary>
        ///   Gets or sets the GFZH
        /// </summary>
        [StringLength(20)]
        public string Gfzh { get; set; }

        /// <summary>
        ///   Gets or sets the BRXM
        /// </summary>
        [Required]
        [StringLength(40)]
        public string Brxm { get; set; }

        /// <summary>
        ///   Gets or sets the BRXB
        /// </summary>
        [Column(TypeName = "numeric")]
        public int Brxb { get; set; }

        /// <summary>
        ///   Gets or sets the CSNY
        /// </summary>
        public DateTime? Csny { get; set; }

        /// <summary>
        ///   Gets or sets the SFZH
        /// </summary>
        [StringLength(20)]
        public string Sfzh { get; set; }

        /// <summary>
        ///   Gets or sets the HYZK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Hyzk { get; set; }

        /// <summary>
        ///   Gets or sets the ZYDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zydm { get; set; }

        /// <summary>
        ///   Gets or sets the SFDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Sfdm { get; set; }

        /// <summary>
        ///   Gets or sets the JGDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Jgdm { get; set; }

        /// <summary>
        ///   Gets or sets the MZDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Mzdm { get; set; }

        /// <summary>
        ///   Gets or sets the GJDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Gjdm { get; set; }

        /// <summary>
        ///   Gets or sets the DWBH
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Dwbh { get; set; }

        /// <summary>
        ///   Gets or sets the GZDW
        /// </summary>
        [StringLength(40)]
        public string Gzdw { get; set; }

        /// <summary>
        ///   Gets or sets the DWDH
        /// </summary>
        [StringLength(16)]
        public string Dwdh { get; set; }

        /// <summary>
        ///   Gets or sets the DWYB
        /// </summary>
        [StringLength(6)]
        public string Dwyb { get; set; }

        /// <summary>
        ///   Gets or sets the HKDZ
        /// </summary>
        [StringLength(40)]
        public string Hkdz { get; set; }

        /// <summary>
        ///   Gets or sets the HKYB
        /// </summary>
        [StringLength(6)]
        public string Hkyb { get; set; }

        /// <summary>
        ///   Gets or sets the LXRM
        /// </summary>
        [StringLength(10)]
        public string Lxrm { get; set; }

        /// <summary>
        ///   Gets or sets the LXGX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Lxgx { get; set; }

        /// <summary>
        ///   Gets or sets the LXDZ
        /// </summary>
        [StringLength(40)]
        public string Lxdz { get; set; }

        /// <summary>
        ///   Gets or sets the LXDH
        /// </summary>
        [StringLength(16)]
        public string Lxdh { get; set; }

        /// <summary>
        ///   Gets or sets the PZHM
        /// </summary>
        [StringLength(10)]
        public string Pzhm { get; set; }

        /// <summary>
        ///   Gets or sets the SBHM
        /// </summary>
        [StringLength(20)]
        public string Sbhm { get; set; }

        /// <summary>
        ///   Gets or sets the DBRM
        /// </summary>
        [StringLength(10)]
        public string Dbrm { get; set; }

        /// <summary>
        ///   Gets or sets the DBGX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Dbgx { get; set; }

        /// <summary>
        ///   Gets or sets the ZZTX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zztx { get; set; }

        /// <summary>
        ///   Gets or sets the DBBZ
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Dbbz { get; set; }

        /// <summary>
        ///   Gets or sets the BRKS
        /// </summary>
        public decimal Brks { get; set; }

        /// <summary>
        ///   Gets or sets the BRBQ
        /// </summary>
        [Column(TypeName = "numeric")]
        public int? Brbq { get; set; }

        /// <summary>
        ///   Gets or sets the BRCH
        /// </summary>
        [StringLength(6)]
        public string Brch { get; set; }

        /// <summary>
        ///   Gets or sets the DJRQ
        /// </summary>
        public DateTime Djrq { get; set; }

        /// <summary>
        ///   Gets or sets the RYRQ
        /// </summary>
        public DateTime Ryrq { get; set; }

        /// <summary>
        ///   Gets or sets the CYRQ
        /// </summary>
        public DateTime? Cyrq { get; set; }

        /// <summary>
        ///   Gets or sets the CYPB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Cypb { get; set; }

        /// <summary>
        ///   Gets or sets the CYFS
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Cyfs { get; set; }

        /// <summary>
        ///   Gets or sets the CZGH
        /// </summary>
        [StringLength(10)]
        public string Czgh { get; set; }

        /// <summary>
        ///   Gets or sets the RYQK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Ryqk { get; set; }

        /// <summary>
        ///   Gets or sets the BRQK
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Brqk { get; set; }

        /// <summary>
        ///   Gets or sets the HLJB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Hljb { get; set; }

        /// <summary>
        ///   Gets or sets the YSDM
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Ysdm { get; set; }

        /// <summary>
        ///   Gets or sets the BRXX
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Brxx { get; set; }

        /// <summary>
        ///   Gets or sets the hzks
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Hzks { get; set; }

        /// <summary>
        ///   Gets or sets the jcks
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Jcks { get; set; }

        /// <summary>
        ///   Gets or sets the MZYS
        /// </summary>
        [StringLength(10)]
        public string Mzys { get; set; }

        /// <summary>
        ///   Gets or sets the ZYYS
        /// </summary>
        [StringLength(10)]
        public string Zyys { get; set; }

        /// <summary>
        ///   Gets or sets the ZSYS
        /// </summary>
        [StringLength(10)]
        public string Zsys { get; set; }

        /// <summary>
        ///   Gets or sets the ZZYS
        /// </summary>
        [StringLength(10)]
        public string Zzys { get; set; }

        /// <summary>
        ///   Gets or sets the qzrq
        /// </summary>
        public DateTime? Qzrq { get; set; }

        /// <summary>
        ///   Gets or sets the ksrq
        /// </summary>
        public DateTime? Ksrq { get; set; }

        /// <summary>
        ///   Gets or sets the jsrq
        /// </summary>
        public DateTime? Jsrq { get; set; }

        /// <summary>
        ///   Gets or sets the jscs
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Jscs { get; set; }

        /// <summary>
        ///   Gets or sets the jzrq
        /// </summary>
        public DateTime? Jzrq { get; set; }

        /// <summary>
        ///   Gets or sets the hzrq
        /// </summary>
        public DateTime? Hzrq { get; set; }

        /// <summary>
        ///   Gets or sets the XGPB
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Xgpb { get; set; }

        /// <summary>
        ///   Gets or sets the bapb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Bapb { get; set; }

        /// <summary>
        ///   Gets or sets the brgl
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Brgl { get; set; }

        /// <summary>
        ///   Gets or sets the brkl
        /// </summary>
        [StringLength(6)]
        public string Brkl { get; set; }

        /// <summary>
        ///   Gets or sets the bz
        /// </summary>
        [StringLength(250)]
        public string Bz { get; set; }

        /// <summary>
        ///   Gets or sets the brqm
        /// </summary>
        [StringLength(32)]
        public string Brqm { get; set; }

        /// <summary>
        ///   Gets or sets the jtdh
        /// </summary>
        [StringLength(16)]
        public string Jtdh { get; set; }

        /// <summary>
        ///   Gets or sets the ybkh
        /// </summary>
        [StringLength(50)]
        public string Ybkh { get; set; }

        /// <summary>
        ///   Gets or sets the jzkh
        /// </summary>
        [StringLength(40)]
        public string Jzkh { get; set; }

        /// <summary>
        ///   Gets or sets the SZYS
        /// </summary>
        [StringLength(10)]
        public string Szys { get; set; }

        /// <summary>
        ///   Gets or sets the zlxz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zlxz { get; set; }

        /// <summary>
        ///   Gets or sets the spje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Spje { get; set; }

        /// <summary>
        ///   Gets or sets the sjzy
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Sjzy { get; set; }

        /// <summary>
        ///   Gets or sets the djbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Djbz { get; set; }

        /// <summary>
        ///   Gets or sets the djid
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Djid { get; set; }

        /// <summary>
        ///   Gets or sets the djje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal Djje { get; set; }

        /// <summary>
        ///   Gets or sets the ysjs
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Ysjs { get; set; }

        /// <summary>
        ///   Gets or sets the zkzt
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zkzt { get; set; }

        /// <summary>
        ///   Gets or sets the grbh_yh
        /// </summary>
        [StringLength(30)]
        [Column("grbh_yh")]
        public string Grbh_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the ybkh_yh
        /// </summary>
        [StringLength(30)]
        [Column("ybkh_yh")]
        public string Ybkh_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the rylb_yh
        /// </summary>
        [Column("rylb_yh")]
        public decimal? Rylb_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the lbmc_yh
        /// </summary>
        [StringLength(30)]
        [Column("lbmc_yh")]
        public string Lbmc_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the knxx_yh
        /// </summary>
        [StringLength(30)]
        [Column("knxx_yh")]
        public string Knxx_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the ywxlh_yh
        /// </summary>
        [StringLength(30)]
        [Column("ywxlh_yh")]
        public string Ywxlh_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the zycs_yh
        /// </summary>
        [Column("zycs_yh")]
        public decimal? Zycs_Yh { get; set; }

        /// <summary>
        ///   Gets or sets the bargainingid
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Bargainingid { get; set; }

        /// <summary>
        ///   Gets or sets the yylsh
        /// </summary>
        [StringLength(40)]
        public string Yylsh { get; set; }

        /// <summary>
        ///   Gets or sets the ycts
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Ycts { get; set; }

        /// <summary>
        ///   Gets or sets the khmm
        /// </summary>
        [StringLength(10)]
        public string Khmm { get; set; }

        /// <summary>
        ///   Gets or sets the grbh
        /// </summary>
        [StringLength(20)]
        public string Grbh { get; set; }

        /// <summary>
        ///   Gets or sets the bzbh
        /// </summary>
        [StringLength(10)]
        public string Bzbh { get; set; }

        /// <summary>
        ///   Gets or sets the qgyz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qgyz { get; set; }

        /// <summary>
        ///   Gets or sets the dylb
        /// </summary>
        [StringLength(4)]
        public string Dylb { get; set; }

        /// <summary>
        ///   Gets or sets the icmw
        /// </summary>
        [StringLength(500)]
        public string Icmw { get; set; }

        /// <summary>
        ///   Gets or sets the rylx
        /// </summary>
        public decimal? Rylx { get; set; }

        /// <summary>
        ///   Gets or sets the cjbz_ry
        /// </summary>
        [Column("cjbz_ry")]
        public decimal? Cjbz_Ry { get; set; }

        /// <summary>
        ///   Gets or sets the smkwkh
        /// </summary>
        [StringLength(20)]
        public string Smkwkh { get; set; }

        /// <summary>
        ///   Gets or sets the kzhm
        /// </summary>
        [StringLength(30)]
        public string Kzhm { get; set; }

        /// <summary>
        ///   Gets or sets the jsdh
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Jsdh { get; set; }

        /// <summary>
        ///   Gets or sets the scjl
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Scjl { get; set; }

        /// <summary>
        ///   Gets or sets the gwyjb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Gwyjb { get; set; }

        /// <summary>
        ///   Gets or sets the icd9
        /// </summary>
        [StringLength(10)]
        public string Icd9 { get; set; }

        /// <summary>
        ///   Gets or sets the zxlsh
        /// </summary>
        [StringLength(30)]
        public string Zxlsh { get; set; }

        /// <summary>
        ///   Gets or sets the ylrylb
        /// </summary>
        [StringLength(10)]
        public string Ylrylb { get; set; }

        /// <summary>
        ///   Gets or sets the fjrylb
        /// </summary>
        [StringLength(10)]
        public string Fjrylb { get; set; }

        /// <summary>
        ///   Gets or sets the icxx
        /// </summary>
        [Column(TypeName = "text")]
        public string Icxx { get; set; }

        /// <summary>
        ///   Gets or sets the ickh
        /// </summary>
        [StringLength(30)]
        public string Ickh { get; set; }

        /// <summary>
        ///   Gets or sets the dnzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Dnzhye { get; set; }

        /// <summary>
        ///   Gets or sets the lnzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Lnzhye { get; set; }

        /// <summary>
        ///   Gets or sets the scxh
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Scxh { get; set; }

        /// <summary>
        ///   Gets or sets the ryxz
        /// </summary>
        [StringLength(2)]
        public string Ryxz { get; set; }

        /// <summary>
        ///   Gets or sets the cbxz
        /// </summary>
        [StringLength(8)]
        public string Cbxz { get; set; }

        /// <summary>
        ///   Gets or sets the scbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Scbz { get; set; }

        /// <summary>
        ///   Gets or sets the tsbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Tsbz { get; set; }

        /// <summary>
        ///   Gets or sets the cayldh
        /// </summary>
        [StringLength(20)]
        public string Cayldh { get; set; }

        /// <summary>
        ///   Gets or sets the yldh
        /// </summary>
        [StringLength(20)]
        public string Yldh { get; set; }

        /// <summary>
        ///   Gets or sets the zylx
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zylx { get; set; }

        /// <summary>
        ///   Gets or sets the tsbzbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Tsbzbz { get; set; }

        /// <summary>
        ///   Gets or sets the cabzlx
        /// </summary>
        [StringLength(50)]
        public string Cabzlx { get; set; }

        /// <summary>
        ///   Gets or sets the cajzlx
        /// </summary>
        [StringLength(50)]
        public string Cajzlx { get; set; }

        /// <summary>
        ///   Gets or sets the cahmlx
        /// </summary>
        [StringLength(50)]
        public string Cahmlx { get; set; }

        /// <summary>
        ///   Gets or sets the caxsbz
        /// </summary>
        [StringLength(2)]
        public string Caxsbz { get; set; }

        /// <summary>
        ///   Gets or sets the cazh
        /// </summary>
        [StringLength(30)]
        public string Cazh { get; set; }

        /// <summary>
        ///   Gets or sets the cazjlx
        /// </summary>
        [StringLength(50)]
        public string Cazjlx { get; set; }

        /// <summary>
        ///   Gets or sets the cadxbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Cadxbz { get; set; }

        /// <summary>
        ///   Gets or sets the bxlx
        /// </summary>
        [StringLength(20)]
        public string Bxlx { get; set; }

        /// <summary>
        ///   Gets or sets the grzhye
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Grzhye { get; set; }

        /// <summary>
        ///   Gets or sets the rylxmc
        /// </summary>
        [StringLength(30)]
        public string Rylxmc { get; set; }

        /// <summary>
        ///   Gets or sets the xzqydm
        /// </summary>
        [StringLength(6)]
        public string Xzqydm { get; set; }

        /// <summary>
        ///   Gets or sets the yjsrq
        /// </summary>
        public DateTime? Yjsrq { get; set; }

        /// <summary>
        ///   Gets or sets the qfsdbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qfsdbz { get; set; }

        /// <summary>
        ///   Gets or sets the zjje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zjje { get; set; }

        /// <summary>
        ///   Gets or sets the jfje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Jfje { get; set; }

        /// <summary>
        ///   Gets or sets the jsje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Jsje { get; set; }

        /// <summary>
        ///   Gets or sets the qfje
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qfje { get; set; }

        /// <summary>
        ///   Gets or sets the qfdbbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qfdbbz { get; set; }

        /// <summary>
        ///   Gets or sets the qfdbyy
        /// </summary>
        [StringLength(100)]
        public string Qfdbyy { get; set; }

        /// <summary>
        ///   Gets or sets the yllb
        /// </summary>
        [StringLength(3)]
        public string Yllb { get; set; }

        /// <summary>
        ///   Gets or sets the cbd_xzdm
        /// </summary>
        [StringLength(6)]
        [Column("cbd_xzdm")]
        public string Cbd_Xzdm { get; set; }

        /// <summary>
        ///   Gets or sets the blbbh
        /// </summary>
        [StringLength(20)]
        public string Blbbh { get; set; }

        /// <summary>
        ///   Gets or sets the qypb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qypb { get; set; }

        /// <summary>
        ///   Gets or sets the qybr
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Qybr { get; set; }

        /// <summary>
        ///   Gets or sets the dasc
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Dasc { get; set; }

        /// <summary>
        ///   Gets or sets the actnumber
        /// </summary>
        [StringLength(60)]
        public string Actnumber { get; set; }

        /// <summary>
        ///   Gets or sets the url
        /// </summary>
        [StringLength(255)]
        public string Url { get; set; }

        /// <summary>
        ///   Gets or sets the bllx
        /// </summary>
        [StringLength(3)]
        public string Bllx { get; set; }

        /// <summary>
        ///   Gets or sets the jzbh
        /// </summary>
        [StringLength(20)]
        public string Jzbh { get; set; }

        /// <summary>
        ///   Gets or sets the dbz
        /// </summary>
        [StringLength(3)]
        public string Dbz { get; set; }

        /// <summary>
        ///   Gets or sets the dyzt
        /// </summary>
        [StringLength(10)]
        public string Dyzt { get; set; }

        /// <summary>
        ///   Gets or sets the cardno
        /// </summary>
        [StringLength(40)]
        public string Cardno { get; set; }

        /// <summary>
        ///   Gets or sets the jtbc
        /// </summary>
        [StringLength(20)]
        public string Jtbc { get; set; }

        /// <summary>
        ///   Gets or sets the bjbz
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Bjbz { get; set; }

        /// <summary>
        ///   Gets or sets the bjdj
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Bjdj { get; set; }

        /// <summary>
        ///   Gets or sets the yepb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Yepb { get; set; }

        /// <summary>
        ///   Gets or sets the zszpb
        /// </summary>
        [Column(TypeName = "numeric")]
        public decimal? Zszpb { get; set; }

        /// <summary>
        ///   Gets or sets the rylb
        /// </summary>
        [StringLength(10)]
        public string Rylb { get; set; }

        /// <summary>
        ///   Gets or sets the ygys
        /// </summary>
        [StringLength(10)]
        public string Ygys { get; set; }

        /// <summary>
        ///   Gets or sets the brlx
        /// </summary>
        public decimal Brlx { get; set; }

        [Column(TypeName = "numeric")]
        public int Ydjsbz { get; set; }

        [ForeignKey("Brks")]
        public virtual GyKsdm KsBrks { get; set; }
        [ForeignKey("Brxz")]
        public virtual GyBrxz GyBrxz { get; set; }
        [ForeignKey("Zyh")]
        public virtual IList<ZyFymx> ZyFymxs { get; set; }
        [ForeignKey("Zyh")]
        public virtual IList<ZyTbkk> ZyTbkks { get; set; }
        [ForeignKey("Zyh")]
        public virtual IList<ZyRyzd> ZyRyzds { get; set; }
        [ForeignKey("Zzys")]
        public virtual GyYgdm GyYgdm { get; set; }
    }
}
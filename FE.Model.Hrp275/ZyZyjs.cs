using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("zy_zyjs")]
    public sealed class ZyZyjs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZyZyjs()
        {
            ZyJsmxSet = new HashSet<ZyJsmx>();
        }
        [Key, Column(Order = 1)]
        public decimal Zyh { get; set; }
        [Key, Column(Order = 2)]
        public decimal Jscs { get; set; }
        public decimal Jslx { get; set; }
        public DateTime? Ksrq { get; set; }
        public DateTime? Zzrq { get; set; }
        public DateTime Jsrq { get; set; }
        public decimal Fyhj { get; set; }
        public decimal Zfhj { get; set; }
        public decimal Jkhj { get; set; }
        public decimal Xjje { get; set; }
        public decimal Zpje { get; set; }
        public string Zphm { get; set; }
        public string Fphm { get; set; }
        public string Czgh { get; set; }
        public DateTime? Jzrq { get; set; }
        public DateTime? Hzrq { get; set; }
        public string Tphm { get; set; }
        public DateTime? Zfrq { get; set; }
        public string Zfgh { get; set; }
        public decimal Zfpb { get; set; }
        public decimal Qtje { get; set; }
        public decimal? Qtfs { get; set; }
        public string Qthm { get; set; }
        public string Jsxm { get; set; }
        public string Jsjk { get; set; }
        public decimal Srje { get; set; }
        public decimal Brxz { get; set; }
        public decimal? Jrzf { get; set; }
        public decimal? Jrzflx { get; set; }
        public decimal? Czbz { get; set; }
        public decimal? Cjbz { get; set; }
        public decimal? Jkda { get; set; }
        public decimal? Jgid { get; set; }
        public string Fpdyr { get; set; }
        public string Czlx { get; set; }
        public DateTime? Dyhzrq { get; set; }
        public DateTime? Dyjzrq { get; set; }
        public DateTime? Fpdysj { get; set; }
        public decimal? Czbq { get; set; }
        public decimal? Zylb { get; set; }
        public decimal? Jmje { get; set; }
        public decimal? Yef { get; set; }
        public string Paylsh { get; set; }
        public string Dzpj { get; set; }
        public decimal? Jsjkxh { get; set; }
        public string Sjfp { get; set; }
        public string Pzh { get; set; }
        public string Szzw { get; set; }
        public string Jym { get; set; }
        public string Jdph { get; set; }
        public string Pjdm { get; set; }
        public string Pjhm { get; set; }
        public DateTime? Kpsj { get; set; }

        public ZyBrry ZyBrry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ZyJsmx> ZyJsmxSet { get; set; }

    }
}

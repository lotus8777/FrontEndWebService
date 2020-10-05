using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("ms_mzxx")]
    public class MsMzxx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsMzxx()
        {
            MsSfmxSet = new HashSet<MsSfmx>();
        }
        [Key]
        public decimal Mzxh { get; set; }
        public string Fphm { get; set; }
        public DateTime? Sfrq { get; set; }
        public decimal? Brid { get; set; }
        public string Brxm { get; set; }
        public decimal? Brxb { get; set; }
        public decimal? Brxz { get; set; }
        public string Fyzh { get; set; }
        public decimal? Dwxh { get; set; }
        public decimal Xjje { get; set; }
        public decimal Zpje { get; set; }
        public decimal Zhje { get; set; }
        public decimal Hbwc { get; set; }
        public decimal Qtys { get; set; }
        public decimal Zjje { get; set; }
        public decimal Zfje { get; set; }
        public decimal? Zhlb { get; set; }
        public decimal Zfpb { get; set; }
        public decimal Thpb { get; set; }
        public string Fpgl { get; set; }
        public decimal? Mzgl { get; set; }
        public decimal Mzlb { get; set; }
        public decimal? Ghgl { get; set; }
        public string Czgh { get; set; }
        public DateTime? Jzrq { get; set; }
        public DateTime? Hzrq { get; set; }
        public decimal Sffs { get; set; }
        public string Sjfp { get; set; }
        public decimal? Jyxh { get; set; }
        public decimal? Jrzf { get; set; }
        public decimal? Jrzflx { get; set; }
        public decimal? Czbz { get; set; }
        public decimal? Cjbz { get; set; }
        public decimal? Dnzh { get; set; }
        public decimal? Lnzh { get; set; }
        public decimal? Czfje { get; set; }
        public decimal? Yhje { get; set; }
        public string Yydm { get; set; }
        public decimal Rlje { get; set; }
        public decimal? Jzh { get; set; }
        public decimal? Tjpb { get; set; }
        public decimal? Qybr { get; set; }
        public decimal? Ylje { get; set; }
        public decimal? Jkda { get; set; }
        public string Paylsh { get; set; }
        public string Sjfp_Cd { get; set; }
        public decimal? Jzbz { get; set; }
        public decimal? Qtfs { get; set; }
        public decimal? Qtje { get; set; }
        public string Xnfp { get; set; }
        public decimal? Jgid { get; set; }
        public decimal? Tzje { get; set; }
        public decimal? Jkje { get; set; }
        public decimal? Hbbz { get; set; }
        public string Dzpj { get; set; }
        public string Pzh { get; set; }
        public string Szzw { get; set; }
        public string Jym { get; set; }
        public string Jdph { get; set; }
        public string Pjdm { get; set; }
        public string Pjhm { get; set; }
        public DateTime? Kpsj { get; set; }
        public decimal? Tstdxz { get; set; }
        public decimal? Tstdje { get; set; }
        public decimal? Tdjeshbz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MsSfmx> MsSfmxSet { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 公用-代码字典
    /// </summary>
    [Table("gy_dmzd")]
    public class GyDmzd
    {
        [Key]
        [Column(Order = 0)]
        public decimal Dmlb { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Dmsb { get; set; }

        public string Srdm { get; set; }
        public string Dmmc { get; set; }
        public string Bzbm { get; set; }
        public decimal Xtsb { get; set; }
        public string DmsbEmr { get; set; }
        public string DmlbEmr { get; set; }
        public string Mpicode { get; set; }
        public decimal? Lxzt { get; set; }
        public decimal? Zfpb { get; set; }
    }
}
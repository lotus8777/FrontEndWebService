using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    /// 公用-代码字典
    /// </summary>
    [Table("gy_dmzd")]
    public class GyDmzd
    {
        [Key]
        [Column(Order = 0)]
        public decimal dmlb { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal dmsb { get; set; }

        public string srdm { get; set; }
        public string dmmc { get; set; }
        public string bzbm { get; set; }
        public decimal xtsb { get; set; }
        public string dmsb_emr { get; set; }
        public string dmlb_emr { get; set; }
        public string MPICODE { get; set; }
        public decimal? LXZT { get; set; }
        public decimal? ZFPB { get; set; }
    }
}
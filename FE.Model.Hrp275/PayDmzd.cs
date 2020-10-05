using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 支付-代码字典
    /// </summary>
    [Table("pay_dmzd")]
    public class PayDmzd
    {
        [Key]
        [Column(Order = 0)]
        public string Dmlb { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Dmsb { get; set; }

        public string Dmmc { get; set; }
        public string Dmbz { get; set; }
        public string Pydm { get; set; }
    }
}
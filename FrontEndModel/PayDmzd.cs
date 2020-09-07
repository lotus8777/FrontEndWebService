using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndModel
{
    /// <summary>
    /// 支付-代码字典
    /// </summary>
    [Table("pay_dmzd")]
    public  class PayDmzd
    {
        [Key]
        [Column(Order = 0)]
        public string dmlb { get; set; }
        [Key]
        [Column(Order = 1)]
        public string dmsb { get; set; }
        public string dmmc { get; set; }
        public string dmbz { get; set; }
        public string pydm { get; set; }
    }
}

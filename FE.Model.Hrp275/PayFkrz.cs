using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    [Table("pay_fkrz")]
    public class PayFkrz
    {
        /// <summary>
        /// 记录序号
        /// </summary>
        [Key]
        public int Jlxh { get; set; }
        /// <summary>
        /// 入参
        /// </summary>
        public string Instr { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public string Jydm { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string Jylx { get; set; }
        /// <summary>
        /// 写入日期
        /// </summary>
        public DateTime Xrrq { get; set; }
        /// <summary>
        /// 医院结算流水
        /// </summary>
        public string Yyjsls { get; set; }
    }
}

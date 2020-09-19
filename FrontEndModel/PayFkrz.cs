using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{
    [Table("pay_fkrz")]
    public class PayFkrz
    {
        /// <summary>
        /// 记录序号
        /// </summary>
        [Key]
        public int jlxh { get; set; }
        /// <summary>
        /// 入参
        /// </summary>
        public string instr { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public string jydm { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string jylx { get; set; }
        /// <summary>
        /// 写入日期
        /// </summary>
        public DateTime xrrq { get; set; }
        /// <summary>
        /// 医院结算流水
        /// </summary>
        public string yyjsls { get; set; }
    }
}

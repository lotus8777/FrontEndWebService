using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Local
{
    /// <summary>
    /// 挂号处理参数
    /// </summary>
    public class GhclParameter
    {
        public string brxm { get; set; }
        public string sfzh { get; set; }
        public string jtdz { get; set; }
        public string grbh { get; set; }
        public DateTime csny { get; set; }
        public int brxb { get; set; }
        public string gddh { get; set; }
        public string tel { get; set; }
        public string cardnum { get; set; }
        public string ybkh { get; set; }
        public string smkNo { get; set; }
        public int cardtype { get; set; }
        public DateTime gzrq { get; set; }
        public int zblb { get; set; }
        public string ksdm { get; set; }
        public string ysdm { get; set; }
        public decimal jzxh { get; set; }
        public string ghdw { get; set; }
        public string ghry { get; set; }
        public string pzhm { get; set; }
        public DateTime jzsj { get; set; }
        public DateTime jzsj2 { get; set; }
        public int brxz { get; set; } = 0;
        public int qybr { get; set; } = 0;
        public int ghlb { get; set; }
        public int mzks { get; set; }
        public int brid { get; set; }
        public string jzhm { get; set; }
        public int yylb { get; set; } = 5;
        public int yyxh { get; set; }
        public int ghxh { get; set; }
        public int yj01xh { get; set; }
        public int[] yj02xh
        {
            get;
            set;

        }
        /// <summary>
        /// 费用序号，费用金额
        /// </summary>
        public IList<Tuple<int ,decimal>> ZlfList { get; set; }
    }
}

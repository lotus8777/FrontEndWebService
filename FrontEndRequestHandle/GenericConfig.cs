using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndRequestHandle
{
    public class GenericConfig
    {
        
        public string YYBH { get; set; }
        public string CZGH { get; set; }
        public string HZYB_BRXZ { get; set; }
        public string WXYB_BRXZ { get; set; }
        public int CFXQ { get; set; } = 1;
        public int WebCFXQ { get; set; } = 1;
        /// <summary>
        /// 省一卡通
        /// </summary>
        public string SYKT { get; set; }

        public int ZCFGB { get; set; }
        public int JZZCF { get; set; }
        public int TXZCF { get; set; }
        public int ZJZCFZG { get; set; }
        public int ZJZCFFG { get; set; }
        public int PTZCF { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{
    /// <summary>
    /// 银行卡签约记录表
    /// </summary>
    [Table("ms_brda_yhqy")]
   public class MzYhkqy
    {
        [Column(TypeName = "decimal")]
        public int brid { get; set; }
        public string lxr { get; set; }
        public string lxrdh { get; set; }
        public int ? yllb { get; set; }
        public string yhkh { get; set; }
        [Column(TypeName = "decimal")]
        public int qybr { get; set; }
        [Column(TypeName = "decimal")]
        public int zfpb { get; set; }
        public string signunitname { get; set; }
        public string signuser { get; set; }
        public string ysed { get; set; }
        public string yslsh { get; set; }
        public string yhpch { get; set; }
        public string yhpjh { get; set; }
    }
}

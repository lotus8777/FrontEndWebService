using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    /// <summary>
    /// 银行卡签约记录表
    /// </summary>
    [Table("ms_brda_yhqy")]
   public class MsYhkqy
    {
        [Column(TypeName = "decimal")]
        public int Brid { get; set; }
        public string Lxr { get; set; }
        public string Lxrdh { get; set; }
        public int ? Yllb { get; set; }
        public string Yhkh { get; set; }
        [Column(TypeName = "decimal")]
        public int Qybr { get; set; }
        [Column(TypeName = "decimal")]
        public int Zfpb { get; set; }
        public string Signunitname { get; set; }
        public string Signuser { get; set; }
        public string Ysed { get; set; }
        public string Yslsh { get; set; }
        public string Yhpch { get; set; }
        public string Yhpjh { get; set; }
    }
}

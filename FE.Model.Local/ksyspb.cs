using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FE.Model.Local;

namespace FE.Model.Local
{
    /// <summary>
    /// 科室医生排班状态
    /// </summary>
   public class ksyspb:ToXElement
    {
        public DateTime gzrq { get; set; }
        public decimal zblb { get; set; }
        public string ysdm { get; set; }
        public string ysxm { get; set; }
        public string djyssfzh { get; set; }
        public decimal ghxe { get; set; }
        public int zjpb { get; set; }
        public int ghlb  { get; set; }
        public decimal ghje { get; set; }
        public int pbzt { get; set; }
    }
}

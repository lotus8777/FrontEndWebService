using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    [Table("temp_proc_ydjs")]
    public class TempProcYdjs
    {
        public string Tbname { get; set; }
        public decimal? Xh { get; set; }
        public string Xm { get; set; }

        public string Fphm { get; set; }
        public decimal? Zjje { get; set; }
        public decimal? Zfje { get; set; }
        public decimal? Zlje { get; set; }
    }
}

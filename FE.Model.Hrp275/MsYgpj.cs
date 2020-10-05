using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    [Table("ms_ygpj")]
    public class MsYgpj
    {
        [Key]
        public string Ygdm { get; set; }
        public DateTime Lyrq { get; set; }
        [Column(TypeName = "decimal")]
        public int Pjlx { get; set; }
        public string Qshm { get; set; }
        public string Zzhm { get; set; }
        public string Syhm { get; set; }
        [Column(TypeName = "decimal")]
        public int Sypb { get; set; }
        [Column(TypeName = "decimal")]
        public int Jgid { get; set; }
    }
}

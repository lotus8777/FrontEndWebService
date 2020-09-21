using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{
    [Table("ms_ygpj")]
    public class MzYgpj
    {
        [Key]
        public string ygdm { get; set; }
        public DateTime lyrq { get; set; }
        [Column(TypeName = "decimal")]
        public int pjlx { get; set; }
        public string qshm { get; set; }
        public string zzhm { get; set; }
        public string syhm { get; set; }
        [Column(TypeName = "decimal")]
        public int sypb { get; set; }
        [Column(TypeName = "decimal")]
        public int jgid { get; set; }
    }
}

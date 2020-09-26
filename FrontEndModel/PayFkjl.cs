using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    [Table("pay_fkjl")]
    public class PayFkjl
    {
        [Key]
        public string Yyjsls { get; set; }
        public DateTime Jlsj { get; set; }
        [Column(TypeName = "decimal")]
        public int Jzlx { get; set; }
        public string Fphm { get; set; }
        public decimal Pay1 { get; set; }
        public decimal Pay2 { get; set; }
        public string Code { get; set; }
        public string Zffs { get; set; }
        public string Czgh { get; set; }
        [Column(TypeName = "decimal")]
        public int Zfpb { get; set; }

        public DateTime? Zfrq { get; set; }
        public string Zfgh { get; set; }
        [Column(TypeName = "decimal")]
        public int State { get; set; }
        public string ActNumber { get; set; }
        public string Brxm { get; set; }
        public string Tel { get; set; }
        public string Sfzh { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{

    [Table("GY_IDENTITY")]
    public class GyIdentity
    {
        [Key]
        public string Bmc { get; set; }

        public int Csz { get; set; }
        [Column(TypeName = "decimal")]
        public int Dqz { get; set; }
        public int Dzz { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{
    [Table("GY_IDENTITY_MS")]
    public class MzIdentity
    {
        [Key]
        public string bmc { get; set; }

        public int csz { get;set; }
        [Column(TypeName = "decimal")]
        public int dqz { get; set; }
        public int dzz { get; set; }
    }
}

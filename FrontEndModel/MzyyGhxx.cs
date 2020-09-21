using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{
    [Table("mzyy_ghxx")]
    public class MzyyGhxx
    {
        [Key]
        public string pzhm { get; set; }
        public string brid { get; set; }

        public DateTime jzrq { get; set; }
        public string zblb { get; set; }

        public string pbid { get; set; }
        [Column(TypeName = "numeric")]
        public int yyxh { get; set; }

        public string fwbh { get; set; }
        public string czgh { get; set; }
        [Column(TypeName = "numeric")]
        public int yyzt { get; set; }

        public decimal? jzid { get; set; }
        public DateTime? qhsj { get; set; }
        public DateTime? jzsj { get; set; }
        public DateTime? yzsj { get; set; }
        public DateTime? sfsj { get; set; }
        public DateTime? qysj { get; set; }
        [Column(TypeName = "decimal")]
        public int scbz { get; set; }
        public int? xwbz { get; set; }
    }
}

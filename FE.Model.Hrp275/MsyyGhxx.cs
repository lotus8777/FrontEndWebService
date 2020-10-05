using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Model.Hrp275
{
    [Table("mzyy_ghxx")]
    public class MsyyGhxx
    {
        [Key]
        public string Pzhm { get; set; }
        public string Brid { get; set; }

        public DateTime Jzrq { get; set; }
        public string Zblb { get; set; }

        public string Pbid { get; set; }
        [Column(TypeName = "numeric")]
        public int Yyxh { get; set; }

        public string Fwbh { get; set; }
        public string Czgh { get; set; }
        [Column(TypeName = "numeric")]
        public int Yyzt { get; set; }

        public decimal? Jzid { get; set; }
        public DateTime? Qhsj { get; set; }
        public DateTime? Jzsj { get; set; }
        public DateTime? Yzsj { get; set; }
        public DateTime? Sfsj { get; set; }
        public DateTime? Qysj { get; set; }
        [Column(TypeName = "decimal")]
        public int Scbz { get; set; }
        public int? Xwbz { get; set; }
    }
}

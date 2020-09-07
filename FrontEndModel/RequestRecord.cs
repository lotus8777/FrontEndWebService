using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndModel
{

    [Table("wjj_request")]
    public class RequestRecord
    {
        [Key]
        public string RequestId { get; set; } = Guid.NewGuid().ToString("N");
        public string ProcedureName { get; set; }
        public string InXml { get; set; }
        public string OutXml { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public DateTime ResponseTime { get; set; }
    }
}

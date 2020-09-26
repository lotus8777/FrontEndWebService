using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{
    [Table("wjj_request")]
    public class WjjRequest
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
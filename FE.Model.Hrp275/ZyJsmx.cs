using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.Model.Hrp275
{

    [Table("zy_jsmx")]
    public  class ZyJsmx
    {
        [Key, Column(Order = 1)]
        public decimal Zyh { get; set; }
        [Key, Column(Order = 2)]
        public decimal Jscs { get; set; }
        [Key, Column(Order = 3)]
        public decimal Ksdm { get; set; }
        [Key, Column(Order = 4)]
        public decimal Fyxm { get; set; }
        public decimal Zjje { get; set; }
        public decimal Zfje { get; set; }
        public decimal Zlje { get; set; }
        public decimal? Jgid { get; set; }
    
        public virtual ZyZyjs ZyZyjs { get; set; }
        [ForeignKey("Fyxm")]
        public virtual GySfxm GySfxm { get; set; }
    }
}

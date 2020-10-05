namespace FE.Model.Hrp275
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("hzyb_dmzd")]
    public class HzybDmzd
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Dmlb { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Dmsb { get; set; }

        [StringLength(100)]
        public string Dmmc { get; set; }

        [StringLength(200)]
        public string Bz { get; set; }
    }
}
namespace FE.Model.Hrp275
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("gy_xtcs")]
    public class GyXtcs
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Xtsb { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Csmc { get; set; }

        [StringLength(80)]
        public string Csz { get; set; }

        [StringLength(40)]
        public string Mrz { get; set; }

        [StringLength(80)]
        public string Bz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Xgpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Jgid { get; set; }
    }
}
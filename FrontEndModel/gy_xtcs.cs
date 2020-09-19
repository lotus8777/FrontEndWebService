namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class gy_xtcs
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int xtsb { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string csmc { get; set; }

        [StringLength(80)]
        public string csz { get; set; }

        [StringLength(40)]
        public string mrz { get; set; }

        [StringLength(80)]
        public string bz { get; set; }

        [Column(TypeName = "numeric")]
        public decimal xgpb { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? JGID { get; set; }
    }
}
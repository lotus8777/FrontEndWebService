namespace FrontEndModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class hzyb_dmzd
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string dmlb { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string dmsb { get; set; }

        [StringLength(100)]
        public string dmmc { get; set; }

        [StringLength(200)]
        public string bz { get; set; }
    }
}
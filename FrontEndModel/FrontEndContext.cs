using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FrontEndModel
{
    //[DbConfigurationType(typeof(NpgSqlConfiguration))]
    public class FrontEndContext : DbContext
    {
        public FrontEndContext() : base("hrp275")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //修改schema，默认dbo
            //modelBuilder.HasDefaultSchema("public");
            // 处理表名小写
            modelBuilder.Types().Configure(c => c.ToTable(c.ClrType.Name.ToLower()));
            // 处理字段名小写
            modelBuilder.Properties().Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToLower()));
            //生成表名为单数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<RequestRecord> RequestRecords { get; set; }
        public virtual DbSet<MzFsdYy> MzFsdYySet { get; set; }
        public virtual DbSet<ZyBrry> ZyBrrySet { get; set; }
        public virtual DbSet<GyDmzd> GyDmzdSet { get; set; }
        public virtual DbSet<MzGhks> MzGhksSet { get; set; }
        public virtual DbSet<MzBrda> MzBrdaSet { get; set; }
        public virtual DbSet<MzGhmx> MzGhmxSet { get; set; }
        public virtual DbSet<MzYspb> MzYspbSet { get; set; }
        public virtual DbSet<MzYygh> MzYyghSet { get; set; }
        public virtual DbSet<PayDmzd> PayDmzdSet { get; set; }
        public virtual DbSet<gy_jbbm> gy_jbbm { get; set; }
        public virtual DbSet<gy_ksdm> gy_ksdm { get; set; }
        public virtual DbSet<gy_xtcs> gy_xtcs { get; set; }
        public virtual DbSet<gy_ygdm> gy_ygdm { get; set; }
        public virtual DbSet<gy_ylsf> gy_ylsf { get; set; }
        public virtual DbSet<hzyb_dmzd> hzyb_dmzd { get; set; }
        public virtual DbSet<hzyb_ka63> hzyb_ka63 { get; set; }
        public virtual DbSet<ms_cf01> ms_cf01 { get; set; }
        public virtual DbSet<ms_cf02> ms_cf02 { get; set; }
        public virtual DbSet<ms_yj01> ms_yj01 { get; set; }
        public virtual DbSet<ms_yj02> ms_yj02 { get; set; }
        public virtual DbSet<yb_fydz> yb_fydz { get; set; }
        public virtual DbSet<yb_ypdz_new> yb_ypdz_new { get; set; }
        public virtual DbSet<yk_typk> yk_typk { get; set; }
        public virtual DbSet<ys_mz_jbzd> ys_mz_jbzd { get; set; }
        public virtual DbSet<ys_mz_jzls> ys_mz_jzls { get; set; }
        public virtual DbSet<zy_fymx> zy_fymx { get; set; }
        public virtual DbSet<zy_ryzd> zy_ryzd { get; set; }
        public virtual DbSet<zy_tbkk> zy_tbkk { get; set; }
        public virtual DbSet<zy_ypyf> zy_ypyf { get; set; }
    }
}
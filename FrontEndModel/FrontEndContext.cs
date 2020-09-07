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
        public virtual DbSet<GyDmzd> GyDmzdSet { get; set; }
        public virtual DbSet<MzGhks> MzGhksSet { get; set; }
        public virtual DbSet<MzBrda> MzBrdaSet { get; set; }
        public virtual DbSet<MzGhmx> MzGhmxSet { get; set; }
        public virtual DbSet<MzYspb> MzYspbSet { get; set; }
        public virtual DbSet<MzYygh> MzYyghSet { get; set; }
        public virtual DbSet<PayDmzd> PayDmzdSet { get; set; }

    }
}

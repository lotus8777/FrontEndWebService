using FE.Model.Hrp275;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FE.Context
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
        //MzyyGhxx
        public virtual DbSet<ZyJsmx> ZyJsmxSet { get; set; }
        public virtual DbSet<ZyCwsz> ZyCwszSet { get; set; }
        public virtual DbSet<ZyJszf> ZyJszfSet { get; set; }
        public virtual DbSet<ZyZyjs> ZyZyjsSet { get; set; }
        public virtual DbSet<MsMzxx> MsMzxxSet { get; set; }
        public virtual DbSet<MsSfmx> MsSfmxSet { get; set; }
        public virtual DbSet<HzybJsjl> HzybJsjlSet { get; set; }
        public virtual DbSet<BocJsjl> BocJsjlSet { get; set; }
       // public virtual DbSet<MsYjkdyz> MsYjkdyzSet { get; set; }
        public virtual DbSet<GySfxm> GySfxmSet { get; set; }
        public virtual DbSet<ZyBqyz> ZyBqyzSet { get; set; }
        public virtual DbSet<MsyyGhxx> MzyyGhxxSet { get; set; }
        public virtual DbSet<WjjRequest> RequestRecords { get; set; }
        public virtual DbSet<MsFsdYy> MzFsdYySet { get; set; }
        public virtual DbSet<ZyBrry> ZyBrrySet { get; set; }
        public virtual DbSet<GyDmzd> GyDmzdSet { get; set; }
        public virtual DbSet<MsGhks> MzGhksSet { get; set; }
        public virtual DbSet<MsBrda> MzBrdaSet { get; set; }
        public virtual DbSet<MsGhmx> MzGhmxSet { get; set; }
        public virtual DbSet<MsYspb> MzYspbSet { get; set; }
        public virtual DbSet<MsYygh> MzYyghSet { get; set; }
        public virtual DbSet<PayDmzd> PayDmzdSet { get; set; }
        public virtual DbSet<GyJbbm> GyJbbmSet { get; set; }
        public virtual DbSet<GyKsdm> GyKsdmSet { get; set; }
        public virtual DbSet<GyXtcs> GyXtcsSet { get; set; }
        public virtual DbSet<GyYgdm> GyYgdmSet { get; set; }
        public virtual DbSet<GyYlsf> GyYlsfSet { get; set; }
        public virtual DbSet<HzybDmzd> HzybDmzdSet { get; set; }
        public virtual DbSet<HzybKa63> HzybKa63Set { get; set; }
        public virtual DbSet<MsCf01> MsCf01Set { get; set; }
        public virtual DbSet<MsCf02> MsCf02Set { get; set; }
        public virtual DbSet<MsYj01> MsYj01Set { get; set; }
        public virtual DbSet<MsYj02> MsYj02Set { get; set; }
        public virtual DbSet<YbFydz> YbFydzSet { get; set; }
        public virtual DbSet<YbYpdzNew> YbYpdzNewSet { get; set; }
        public virtual DbSet<YkTypk> YkTypkSet { get; set; }
        public virtual DbSet<YsMzJbzd> YsMzJbzdSet { get; set; }
        public virtual DbSet<YsMzJzls> YsMzJzlsSet { get; set; }
        public virtual DbSet<ZyFymx> ZyFymxSet { get; set; }
        public virtual DbSet<ZyRyzd> ZyRyzdSet { get; set; }
        public virtual DbSet<ZyTbkk> ZyTbkkSet { get; set; }
        public virtual DbSet<ZyYpyf> ZyYpyfSet { get; set; }
        public virtual DbSet<PayFkrz> PayFkrzSet { get; set; }
        public virtual DbSet<PayFkjl> PayFkjlSet { get; set; }
        public virtual DbSet<MsIdentity> MzIdentitySet { get; set; }
        public virtual DbSet<GyIdentity> GyIdentitySet { get; set; }
        public virtual DbSet<ZyIdentity> ZyIdentitySet { get; set; }
        public virtual DbSet<MsYgpj> MzYgpjSet { get; set; }
    }
}
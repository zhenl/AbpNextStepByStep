using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.EF.EntityFramework
{
    [ConnectionStringName("Poem")]
    public class PoemDbContext : AbpDbContext<PoemDbContext>,IPoemDbContext
    {
        public virtual DbSet<Poet> Poets { get; set; }

        public PoemDbContext(DbContextOptions<PoemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //映射Poet到数据库表
            modelBuilder.Entity<Poet>(b =>
            {
                b.ToTable("Poet");
                
                //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
                b.Property(p => p.Id)
                        .HasColumnName("PoetID");
                b.ConfigureByConvention();
            });
        }
    }
}

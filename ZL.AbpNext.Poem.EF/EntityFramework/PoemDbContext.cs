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
        public  DbSet<Poet> Poets { get; set; }
        public DbSet<Core.Poems.Poem> Poems { get; set; }
        public DbSet<Category> Categories { get; set ; }
        public DbSet<CategoryPoem> CategoryPoems { get; set; }

        public PoemDbContext(DbContextOptions<PoemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //映射Poet到数据库表
            modelBuilder.Entity<Poet>(b =>
            {
                b.ToTable("Poet");
                
                //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
                b.Property(p => p.Id)
                        .HasColumnName("PoetID");
                b.ConfigureByConvention();
            });

            //Poem映射
            modelBuilder.Entity<Core.Poems.Poem>(b =>
            {
                b.ToTable("Poem");

                //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
                b.Property(p => p.Id)
                        .HasColumnName("PoemId");
                //定义Poem与Poet之间的一对多关系
                b.HasOne<Poet>(s => s.Author)
                        .WithMany(s => s.Poems)
                        .HasForeignKey(s => s.PoetID);
                b.ConfigureByConvention();
            });
            //Category映射
            modelBuilder.Entity<Category>(b =>
            {
                b.ToTable("Category");

                //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
                b.Property(p => p.Id)
                        .HasColumnName("CategoryId");
                b.ConfigureByConvention();
            });
            //CategoryPoem映射
            //modelBuilder.Entity<CategoryPoem>(b =>
            //{
            //    b.ToTable("CategoryPoem");

            //    //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
            //    b.Property(p => p.Id)
            //            .HasColumnName("CategoryPoemId");
            //    //定义多对多关系
            //    b.HasKey(t => new { t.CategoryId, t.PoemId });
            //    b.HasOne(pt => pt.Poem)
            //   .WithMany(p => p.PoemCategories)
            //   .HasForeignKey(pt => pt.PoemId);
            //    b.HasOne(pt => pt.Category)
            //   .WithMany(t => t.CategoryPoems)
            //   .HasForeignKey(pt => pt.CategoryId);
            //    b.ConfigureByConvention();
            //});
            //modelBuilder.Entity<CategoryPoem>(entity =>
            //{
            //    entity.HasOne(d => d.Category)
            //        .WithMany(p => p.CategoryPoem)
            //        .HasForeignKey(d => d.CategoryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CategoryPeom_Category");

            //    entity.HasOne(d => d.Poem)
            //        .WithMany(p => p.CategoryPoem)
            //        .HasForeignKey(d => d.PoemId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CategoryPeom_Peom");
            //});
            //CategoryPoem映射
            modelBuilder.Entity<CategoryPoem>(b =>
            {
                b.ToTable("CategoryPoem");

                //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
                b.Property(p => p.Id)
                        .HasColumnName("CategoryPoemId");
                //定义多对多关系
                //b.HasKey(t => new { t.CategoryId, t.PoemId });
                b.HasOne(pt => pt.Poem)
               .WithMany(p => p.PoemCategories)
               .HasForeignKey(pt => pt.PoemId);

                b.HasOne(pt => pt.Category)
               .WithMany(t => t.CategoryPoems)
               .HasForeignKey(pt => pt.CategoryId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_CategoryPeom_Category");;
                b.ConfigureByConvention();
            });
            base.OnModelCreating(modelBuilder);

        }
    }
}

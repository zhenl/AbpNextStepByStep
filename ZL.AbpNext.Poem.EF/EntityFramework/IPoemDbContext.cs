﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.EF.EntityFramework
{
    [ConnectionStringName("Poem")]
    public interface IPoemDbContext : IEfCoreDbContext
    {
        DbSet<Poet> Poets { get; set; }

        DbSet<Core.Poems.Poem> Poems { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CategoryPoem> CategoryPoems { get; set; }
    }
}

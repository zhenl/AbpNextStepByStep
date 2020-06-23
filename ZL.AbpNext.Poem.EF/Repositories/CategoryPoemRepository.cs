using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ZL.AbpNext.Poem.Core.Poems;
using ZL.AbpNext.Poem.Core.Repositories;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.EF.Repositories
{
    public class CategoryPoemRepository : EfCoreRepository<PoemDbContext, CategoryPoem, int>, ICategoryPoemRepository
    {
        public CategoryPoemRepository(IDbContextProvider<PoemDbContext> dbContextProvider)
        : base(dbContextProvider)
        {

        }
        public List<Category> GetPoemCategories(int poemid)
        {
            var set = DbContext.Set<CategoryPoem>().Include(o => o.Category).AsQueryable();
            var lst = set.Where(p => p.PoemId == poemid).Select(o => o.Category);
            return lst.ToList();
        }

        public List<Core.Poems.Poem> GetPoemsOfCategory(int categoryid)
        {
            var set = DbContext.Set<CategoryPoem>().Include(o => o.Poem).AsQueryable();
            var lst = set.Where(p => p.CategoryId == categoryid).Select(o=>o.Poem);
            return lst.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ZL.AbpNext.Poem.Core.Repositories;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.EF.Repositories
{
    public class PoemRepository : EfCoreRepository<PoemDbContext, Core.Poems.Poem, int>, IPoemRepository
    {
        public PoemRepository(IDbContextProvider<PoemDbContext> dbContextProvider)
        : base(dbContextProvider)
        {

        }

        public Task<List<Core.Poems.Poem>> GetPagedPoems(int maxResult, int skip, string author, string keyword, string[] categories, out int total)
        {
            var set=DbContext.Set<Core.Poems.Poem>().Include(o=>o.Author).Include(o=>o.PoemCategories).AsQueryable();
            if (!string.IsNullOrEmpty(author))
            {
                set = set.Where(o => o.Author.Name == author);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                set = set.Where(o => o.Title.Contains(keyword) );
            }
            if (categories != null && categories.Length > 0)
            {
                foreach (var category in categories)
                {
                    set = set.Where(o => o.PoemCategories.Any(q => q.Category.CategoryName == category));
                }
            }
            total = set.Count();
            var lst = set.OrderBy(o => o.Id).PageBy(skip,maxResult).ToListAsync();
            return lst;
        }
    }
}

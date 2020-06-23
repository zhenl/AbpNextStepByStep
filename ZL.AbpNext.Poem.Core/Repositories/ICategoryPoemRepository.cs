using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Core.Repositories
{
    public interface ICategoryPoemRepository : IRepository<CategoryPoem, int>
    {
        List<Category> GetPoemCategories(int poemid);

        List<Core.Poems.Poem> GetPoemsOfCategory(int categoryid);
    }
}

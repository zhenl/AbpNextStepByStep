using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ZL.AbpNext.Poem.Core.Repositories
{
    public interface IPoemRepository : IRepository<Core.Poems.Poem , int>
    {
        Task<List<Core.Poems.Poem>> GetPagedPoems(int maxResult,int skip,string author,string keyword,out int total);
    }
}

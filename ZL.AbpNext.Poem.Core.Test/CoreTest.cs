using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Core.Test
{
    public class CoreTest:PoemCoreTestBase
    {
        IRepository<Category> categoryRepository;
        public CoreTest()
        {
            categoryRepository = GetRequiredService<IRepository<Category>>();
        }
        [Fact]
        public async Task TestAddCategory()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var cate = categoryRepository.InsertAsync(new Category { CategoryName = "²âÊÔ" }, true);
                Assert.True(cate.Id > 0);
            });
        }
    }
}

using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.EF.Test
{
    public class TestRepository: PoemEFTestBase
    {
        IRepository<Category> categoryRepository;
        public TestRepository()
        {
            categoryRepository = GetRequiredService<IRepository<Category>>();
        }
        [Fact]
        public async Task TestAddCategory()
        {
            await WithUnitOfWorkAsync(async () =>
            {
               var cate= categoryRepository.InsertAsync(new Category { CategoryName = "²âÊÔ" },true);
                Assert.True(cate.Id > 0);
            });
        }
    }
}

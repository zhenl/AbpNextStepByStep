using System;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;
using ZL.AbpNext.Poem.Application.Poems;
using ZL.AbpNext.Poem.Core.Poems;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.Application.Test
{
    public class UnitTest1:PoemTestBase<PoemApplicationTestModule>
    {
        private readonly IPoemAppService _service;

        public UnitTest1()
        {
            _service = GetRequiredService<IPoemAppService>();
        }

              [Fact]
        public async Task TestAddPoet()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var poet = new PoetDto
                {
                    Name = "李白",
                    Description = "诗人"

                };
                //Act
                var addPoet = _service.AddPoet(poet);
               
                Assert.True(addPoet.Id > 0);
                var res = _service.GetPagedPoets(new Volo.Abp.Application.Dtos.PagedResultRequestDto { MaxResultCount = 10, SkipCount = 0 });
                Assert.True(res.TotalCount >1);

            });
        }

        [Fact]
        public async Task TestGetCategories()
        {
            var categories = _service.GetAllCategories();
            Assert.Equal(2, categories.Count);
        }
        [Fact]
        public async Task TestGetPoems()
        {
            var res = _service.GetPagedPoems( new Volo.Abp.Application.Dtos.PagedResultRequestDto { MaxResultCount=1,SkipCount=0 });
            Assert.Equal(3, res.TotalCount);
            Assert.Equal(1, res.Items.Count);
        }
        [Fact]
        public async Task TestSearchPoems()
        {
            var res = _service.SearchPoems(new SearchPoemDto { AuthorName="李白", MaxResultCount = 1, SkipCount = 0 });
            Assert.Equal(2, res.TotalCount);
            Assert.Equal(1, res.Items.Count);
        }
        [Fact]
        public async Task TestSearchPoemsTitle()
        {
            var res = _service.SearchPoems(new SearchPoemDto { Keyword="静", MaxResultCount = 1, SkipCount = 0 });
            Assert.Equal(1, res.TotalCount);
            Assert.Equal(1, res.Items.Count);
        }
        [Fact]
        public async Task TestSearchPoemscategories()
        {
            var res = _service.SearchPoems(new SearchPoemDto { Categories = new string[] { "小学生必背诗词" }, MaxResultCount = 1, SkipCount = 0 });
            Assert.Equal(1, res.TotalCount);
            Assert.Equal(1, res.Items.Count);
        }
    }


}

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
        private readonly IRepository<Poet, int> _appPoet;
        private readonly IPoemAppService _service;

        public UnitTest1()
        {
            _appPoet= GetRequiredService<IRepository<Poet, int>>();
            _service = GetRequiredService<IPoemAppService>();
        }

        [Fact]
        public async Task TestAddPoet()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var poet = new Poet
                {
                    Name = "李白",
                    Description = "诗人"

                };
                //Act
                var addedPoet = await _appPoet.InsertAsync(poet,true);
                Assert.True(_appPoet.Count() ==1);
                //Assert
                Assert.True(addedPoet.Id>0);
            });
        }

        [Fact]
        public async Task TestAddWithServicet()
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
                Assert.True(res.TotalCount == 1);

            });
        }
    }


}

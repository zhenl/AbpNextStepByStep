using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;
using ZL.AbpNext.Poem.Core.Repositories;

namespace ZL.AbpNext.Poem.Application.Test
{
    public class PoetTestDataSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Poet, int> _appPoet;
        private readonly IRepository<Category, int> _appCategory;
        private readonly IPoemRepository _appPoem;
        private readonly IRepository<CategoryPoem, int> _appCategoryPoem;
        public PoetTestDataSeed(IRepository<Poet, int> _appPoet, 
            IRepository<Category, int> _appCategory,
            IPoemRepository _appPoem,
            IRepository<CategoryPoem,int> _appCategoryPoem)
        {
            this._appPoet = _appPoet;
            this._appCategory = _appCategory;
            this._appPoem = _appPoem;
            this._appCategoryPoem = _appCategoryPoem;
        }
        public Task SeedAsync(DataSeedContext context)
        {
            
            var lb=_appPoet.InsertAsync(new Poet
            {
                Name = "李白",
                Description = "诗人"

            }, true).Result        ;

            var df=_appPoet.InsertAsync(new Poet
            {
                Name = "杜甫",
                Description = "诗人"

            }, true).Result;

            var c1=_appCategory.InsertAsync(new Category { CategoryName = "唐诗三百首" },true).Result;
            var c2=_appCategory.InsertAsync(new Category { CategoryName = "小学生必背诗词" },true).Result;

            var p1= _appPoem.InsertAsync(new Core.Poems.Poem
            {
                 Title="静夜思",
                 PoetID =lb.Id

            }).Result;
            var p2=_appPoem.InsertAsync(new Core.Poems.Poem
            {
                Title = "望庐山瀑布",
                PoetID = lb.Id

            }).Result;
            
            var p3=_appPoem.InsertAsync(new Core.Poems.Poem
            {
                Title = "石壕吏",
                PoetID = df.Id

            }).Result;

            //_appCategoryPoem.InsertAsync(new CategoryPoem
            //{
            //    CategoryId = c1.Id,
            //    PoemId = p1.Id
            //},true);

            //_appCategoryPoem.InsertAsync(new CategoryPoem
            //{
            //    CategoryId = c2.Id,
            //    PoemId = p1.Id
            //}, true);

            //_appCategoryPoem.InsertAsync(new CategoryPoem
            //{
            //    CategoryId = c1.Id,
            //    PoemId = p2.Id
            //}, true);

            //_appCategoryPoem.InsertAsync(new CategoryPoem
            //{
            //    CategoryId = c1.Id,
            //    PoemId = p3.Id
            //}, true);

            return Task.CompletedTask;
        }
    }
    
}

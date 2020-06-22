using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Application.Test
{
    public class PoetTestDataSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Poet, int> _appPoet;
        public PoetTestDataSeed(IRepository<Poet, int> _appPoet)
        {
            this._appPoet = _appPoet;
        }
        public Task SeedAsync(DataSeedContext context)
        {
            
            _appPoet.InsertAsync(new Poet
            {
                Name = "李白",
                Description = "诗人"

            }, true);

            _appPoet.InsertAsync(new Poet
            {
                Name = "杜甫",
                Description = "诗人"

            }, true);

            return Task.CompletedTask;
        }
    }
    
}

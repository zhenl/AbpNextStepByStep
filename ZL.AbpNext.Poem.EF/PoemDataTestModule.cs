using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.EF
{
    public class PoemDataTestModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PoemDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlite();
            });
        }
    }
}

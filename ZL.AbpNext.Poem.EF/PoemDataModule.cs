using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.EF
{
    [DependsOn(
    typeof(PoemCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
    )]
    public class PoemDataModule:AbpModule
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
               
                //options.UseSqlServer();
            });
        }
    }
}

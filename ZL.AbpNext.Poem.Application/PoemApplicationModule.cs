using System;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Application.Poems;
using ZL.AbpNext.Poem.Core;

namespace ZL.AbpNext.Poem.Application
{
    [DependsOn(
        typeof(PoemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PoemApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<PoemAppAutoMapperProfile>(validate: true);
            });
        }
    }
}

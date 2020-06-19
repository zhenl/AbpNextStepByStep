using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Application;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.EF;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(PoemCoreModule),
    typeof(PoemApplicationModule),
    typeof(PoemDataModule))]
    public class PoemConsoleClientModule:AbpModule
    {

    }
}

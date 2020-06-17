using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.EF;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    [DependsOn(
    typeof(PoemCoreModule),
    typeof(PoemDataModule))]
    public class PoemConsoleClientModule:AbpModule
    {

    }
}

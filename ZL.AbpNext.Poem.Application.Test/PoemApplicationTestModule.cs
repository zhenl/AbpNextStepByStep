using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.EF;

namespace ZL.AbpNext.Poem.Application.Test
{

    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(PoemCoreModule),
    typeof(PoemApplicationModule),
    typeof(PoemDataModule))]
    public class PoemApplicationTestModule : AbpModule
    {
    }
}

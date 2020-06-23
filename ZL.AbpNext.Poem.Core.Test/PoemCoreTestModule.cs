using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.EF.Test;

namespace ZL.AbpNext.Poem.Core.Test
{
    [DependsOn(
     typeof(PoemEFTestModule)
     )]
    public class PoemCoreTestModule:AbpModule
    {
    }
}

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.Core.Test;
using ZL.AbpNext.Poem.EF;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.Application.Test
{

    [DependsOn(
        typeof(PoemApplicationModule),
     typeof(PoemCoreTestModule)
     )]
    public class PoemApplicationTestModule : AbpModule
    {
       
    }
}

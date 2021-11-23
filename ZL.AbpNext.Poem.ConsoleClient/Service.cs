using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using ZL.AbpNext.Poem.Application.Poems;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    public class Service : ITransientDependency
    {
       
        IPoemAppService appService;
        
        public Service(IPoemAppService appService)
        {
            this.appService = appService;
        }
        public void Run()
        {
            var res=appService.GetPagedPoets(new Volo.Abp.Application.Dtos.PagedResultRequestDto { MaxResultCount = 10, SkipCount = 0 });
            Console.WriteLine(res.TotalCount);
            foreach(var dto in res.Items)
            {
                Console.WriteLine(dto.Name);
            }
        }
    }
}

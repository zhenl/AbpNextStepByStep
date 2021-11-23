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
        //IRepository<Poet> repository;
        //IUnitOfWorkManager uowManager;
        IPoemAppService appService;
        //public Service(IRepository<Poet> repository, IUnitOfWorkManager uowManager)
        //{
        //    this.repository = repository;
        //    this.uowManager = uowManager;
        //}
        public Service(IPoemAppService appService)
        {
            this.appService = appService;
        }
        public void Run()
        {
            //Console.WriteLine("你好");
            //using (var uow = uowManager.Begin(new AbpUnitOfWorkOptions()))
            //{
            //    //获取第一个诗人
            //    //var poet = repository.FirstOrDefault();
            //    var poet = repository.AsQueryable().Include(p => p.Poems).FirstOrDefault();
            //    Console.WriteLine(poet.Name);
            //    Console.WriteLine(poet.Poems.Count());
            //    Console.WriteLine(poet.Poems.ToList()[0].Author.Name);
            //}

            var res=appService.GetPagedPoets(new Volo.Abp.Application.Dtos.PagedResultRequestDto { MaxResultCount = 10, SkipCount = 0 });
            Console.WriteLine(res.TotalCount);
            foreach(var dto in res.Items)
            {
                Console.WriteLine(dto.Name);
            }
        }
    }
}

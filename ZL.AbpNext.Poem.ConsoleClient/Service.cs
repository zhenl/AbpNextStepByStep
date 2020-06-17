using System;
using System.Linq;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    public class Service : ITransientDependency
    {
        public void Run(IRepository<Poet> repository)
        {
            //Console.WriteLine("你好");


            //获取id为1的诗人
            var poet = repository.FirstOrDefault();

            Console.WriteLine(poet.Name);
        }
    }
}

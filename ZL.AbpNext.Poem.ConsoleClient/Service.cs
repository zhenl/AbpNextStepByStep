using System;
using Volo.Abp.DependencyInjection;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    public class Service : ITransientDependency
    {
        public void Run()
        {
            Console.WriteLine("你好");
        }
    }
}

using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<PoemConsoleClientModule>())
            {
                application.Initialize();

                //Resolve a service and use it
                var service =
                    application.ServiceProvider.GetService<Service>();
                service.Run(application.ServiceProvider.GetService<IRepository<Poet>>());

                Console.WriteLine("Press ENTER to stop application...");
                Console.ReadLine();
            }
        }
    }
}

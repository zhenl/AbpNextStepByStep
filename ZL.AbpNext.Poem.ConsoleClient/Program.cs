using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using ZL.AbpNext.Poem.EF.EntityFramework;

namespace ZL.AbpNext.Poem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var application = AbpApplicationFactory.Create<PoemConsoleClientModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            }))
            {
                application.Initialize();
                //var context = application.ServiceProvider.GetService<PoemDbContext>();
                //try
                //{
                //    var b=context.Database.EnsureCreated();

                //}
                //catch (Exception ex)
                //{

                //    throw;
                //}
                
                //var q = context.Poets;
                //var lst=q.ToList();

                //Resolve a service and use it
                var service =
                    application.ServiceProvider.GetService<Service>();
                service.Run();

                Console.WriteLine("Press ENTER to stop application...");
                Console.ReadLine();
            }
        }
    }
}

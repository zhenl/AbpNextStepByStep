using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;


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

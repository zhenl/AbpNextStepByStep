using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZL.AbpNext.Poem.Application;
using ZL.AbpNext.Poem.Core;
using ZL.AbpNext.Poem.EF;

namespace ZL.AbpNext.Poem.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
    typeof(PoemCoreModule),
    typeof(PoemApplicationModule),
    typeof(PoemDataModule))]
    public class PoemWebModule : AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}

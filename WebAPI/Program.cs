using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //service saðlayýcý fabriikasý olarak kullan !! //bu configuration//1.
                //senin .net core altyapýnca ioc altyapýsý var onu kullanma.autofac kullan...
                //install using Autofac.Extensions.DependencyInjection;
                .ConfigureContainer<ContainerBuilder>(builder => //2.
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

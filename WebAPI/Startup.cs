using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //buildin injection mimarisi
            //Autofac , Ninject ,CastleWindsor ,StructureMap ,LightInject , DryInject --> bunlar IoC Container altyapýsý sunuyor
            //Autofac bize aop imkaný sunuyor.

            //Biz AOP yapoacaðýz --> aspect oriented programing
            //we api nin kendi içerisinde bir IoC yapýsý var
            services.AddControllers();
            //AddSingleton demek --> bana arka planda bir referans oluþtur... 
            //IoC ler bizim yerimize new liyor. birisi senden IProduct service isterse ona birtane product manager oluþtur onu ver diyor.
            services.AddSingleton<IProductService, ProductManager>();
            //biri consta IProductService isterse ona product manager new i ver demek 
            services.AddSingleton<IProductDal, EfProductDal>();
            //biri consta IProductDal isterse ona EfProductDal i ver demek 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

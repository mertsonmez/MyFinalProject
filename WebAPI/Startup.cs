using Business.Abstract;
using Business.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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
            //Autofac , Ninject ,CastleWindsor ,StructureMap ,LightInject , DryInject --> bunlar IoC Container altyap�s� sunuyor
            //Autofac bize aop imkan� sunuyor.

            //Biz AOP yapoaca��z --> aspect oriented programing
            //we api nin kendi i�erisinde bir IoC yap�s� var
            services.AddControllers();
            //AddSingleton demek --> bana arka planda bir referans olu�tur... 
            //IoC ler bizim yerimize new liyor. birisi senden IProduct service isterse ona birtane product manager olu�tur onu ver diyor.

            //services.AddSingleton<IProductService, ProductManager>(); //kapatt�k

            //biri consta IProductService isterse ona product manager new i ver demek 

            //services.AddSingleton<IProductDal, EfProductDal>(); // kapatt�k

            //biri consta IProductDal isterse ona EfProductDal i ver demek 

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            ServiceTool.Create(services);
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

            //Middleware asp ya�am d�ng�s�nde hangi yap�lar�n devreye girece�ini tan�ml�yorsunuz.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

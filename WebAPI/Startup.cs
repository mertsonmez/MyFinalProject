using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

            //services.AddSingleton<IProductService, ProductManager>(); //kapattýk

            //biri consta IProductService isterse ona product manager new i ver demek 

            //services.AddSingleton<IProductDal, EfProductDal>(); // kapattýk

            //biri consta IProductDal isterse ona EfProductDal i ver demek 

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Adding SwaggerUI for Api 17.03.2021
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "My Final Project Api", Version = "v1" });
            });



            //10.03.2021
            //CORS control for frotend
            services.AddCors();


            var tokenOptions = Configuration.GetSection(key:"TokenOptions").Get<TokenOptions>();

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

            services.AddDependencyResolvers(new ICoreModule[] { //ister array ister param olarak yapýn.
                new CoreModule()
            });
            //ServiceTool.Create(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //UseHttpsRedirection üzerine eklememiz gerekiyor
            //"localhost:4200" adresten Ne gelirse gelsin izin ver ben bu web siteý biliyor ve güveniytorum demek!!
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200/").AllowAnyHeader());

            app.UseHttpsRedirection();

            //Add swagger
            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My Final Project Api v1");
            });

            app.UseRouting();

            //Middleware asp yaþam döngüsünde hangi yapýlarýn devreye gireceðini tanýmlýyorsunuz.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

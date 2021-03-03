using Core.CrossCuttingConserns.Caching;
using Core.CrossCuttingConserns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {

            serviceCollection.AddMemoryCache();//.net in kendisinin //redise geçersen buna gerek kalmaz ve AşağıdaMemoryCacheManager yerine redis CacheManaager kullanman yeterli !!
            //Hazır bir ICacheManager instance ı oluşturuyor.

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //biri senden ICacheManager isterse ona MemoryCacheManager ı ver diyoruz !!
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();


        }
    }
}

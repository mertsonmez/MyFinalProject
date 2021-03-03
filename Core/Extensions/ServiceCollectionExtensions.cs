using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    //extension yazabilmek için class static olmalı !!
    public static class ServiceCollectionExtensions
    {
        //neyi genişletmek istiyorsak onu this diye veririz.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection , ICoreModule[] modules) 
        {
            //bize eklenen herbir modul için dolulu ekle
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}

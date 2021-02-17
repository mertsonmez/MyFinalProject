using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module // Module diyerek using ini Autofac seçiyorsun.
    {
        protected override void Load(ContainerBuilder builder)
        {
            // birisi senden Iproductservice isterse ona bir tane product manager instance ı ver !!
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            // birisi senden IProductDal isterse ona bir tane Ef Product Dal instance ı ver !!
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();



        }



    }
}

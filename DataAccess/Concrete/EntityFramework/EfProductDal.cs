using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //c# a özel yapı !!
            //using içerisine yazdığımız nesneler using bitince garbage collector e geliyor ve beni bellekten at diyor !!
            //buda daha performanslı çalışmayı sağlıyor!!
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                //eklenen varlık demek addedEntity
                //önce referansına ulaşmamız gerekiyor.
                //git veri kaybnağından benim gönderdiğim productta bir nesneye eşleştir.
                var addedEntity = context.Entry(entity); //referansı yakalama
                addedEntity.State = EntityState.Added; //ekleme olarak durumu set et
                context.SaveChanges();//değişiklikleri kaydet.

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {                
                var deletedEntity = context.Entry(entity);  //referansı yakalama
                deletedEntity.State = EntityState.Deleted;  //silme olarak durumu set et
                context.SaveChanges();                      //değişiklikleri kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //context.Set<Product> bu bizim tablomuz.
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //turnary operator kullanalım.
                // ? select * from Products döndürüyor ilk kısım : ikinci kısım filtreleyip getir ;
                //fil
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();

            }


        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);  //referansı yakalama
                updatedEntity.State = EntityState.Modified;  //güncelleme olarak durumu set et
                context.SaveChanges();                      //değişiklikleri kaydet.
            }
        }
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntitiyFramework
{
    //Generic constraint !!
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            //c# a özel yapı !!
            //using içerisine yazdığımız nesneler using bitince garbage collector e geliyor ve beni bellekten at diyor !!
            //buda daha performanslı çalışmayı sağlıyor!!
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                //eklenen varlık demek addedEntity
                //önce referansına ulaşmamız gerekiyor.
                //git veri kaybnağından benim gönderdiğim TEntityta bir nesneye eşleştir.
                var addedEntity = context.Entry(entity); //referansı yakalama
                addedEntity.State = EntityState.Added; //ekleme olarak durumu set et
                context.SaveChanges();//değişiklikleri kaydet.

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);  //referansı yakalama
                deletedEntity.State = EntityState.Deleted;  //silme olarak durumu set et
                context.SaveChanges();                      //değişiklikleri kaydet.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //context.Set<TEntity> bu bizim tablomuz.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //turnary operator kullanalım.
                // ? select * from TEntitys döndürüyor ilk kısım : ikinci kısım filtreleyip getir ;
                //fil
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);  //referansı yakalama
                updatedEntity.State = EntityState.Modified;  //güncelleme olarak durumu set et
                context.SaveChanges();                      //değişiklikleri kaydet.
            }
        }
    }
}

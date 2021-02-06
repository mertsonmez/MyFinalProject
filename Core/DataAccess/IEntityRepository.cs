using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //generic constraint (generic kısıt demek)
    //class : reference type olabilir demek.
    //T:hem referance type olabilir ve IEntity olabilir veya IEntity implement eden bir nesne olabilir !!
    //IEntity: IEntity olabilir veya IEntity implement eden bir nesne olabilir !! demek.
    //new() : new lenebilir olmalıdır !!!
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Generic repository design pattern uygulayacağız.

        //Expression ????

        //Predicate ???

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Refactoring
        T Get(Expression<Func<T, bool>> filter); // T döndüren get operasyonu

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId);


    }

    //IEntityRepository i Data Access projesinden Core projesindeki Data access e koyduk!!


}

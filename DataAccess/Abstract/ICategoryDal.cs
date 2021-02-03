using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Customer>
    {
        //Generic repository design pattern ile yapalım
        //burada

        //List<Category> GetAll();
        //void Add(Category product);
        //void Update(Category product);
        //void Delete(Category product);

        //List<Category> GetAllByCategory(int categoryId);

    }
}

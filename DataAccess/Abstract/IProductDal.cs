using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    //DAL - Data Access Layer
    //DAO - Data Access Object (Javacılar bunu sever)
    public interface IProductDal : IEntityRepository<Product>
    {
        //interface in operasyonları publictir kendisi değildir. o yüzden public geririz.

        List<ProductDetailDto> GetProductDetails();


        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId);

    }
}

//Code refactoring - kodun iyileştirmesi
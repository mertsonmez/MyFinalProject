﻿using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    //DAL - Data Access Layer
    //DAO - Data Access Object (Javacılar bunu sever)
    public interface IProductDal
    {
        //interface in operasyonları publictir kendisi değildir. o yüzden public geririz.

        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);

    }
}
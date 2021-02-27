using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        //Solid i si kullanmayacağın birşeyi yazma demektir !! interface segregation
        //List<Product> GetAll();
        IDataResult<List<Product>> GetAll(); //T = List of Product

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId);

        //void yerine IResult yaptım
        IResult Add(Product product);

        IResult Update(Product product);
    }
}

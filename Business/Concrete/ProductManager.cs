using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //loosely coupled --
        IProductDal _productDal; // bunların karşılığı nedir i biz dependencyresolvers da tanımlayacağız

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //loosely coupled --

        public IResult Add(Product product)
        {
            //business codes

            _productDal.Add(product);

            //result is a new result
            //Result result = new Result();

            if (product.ProductName.Length < 2)
            {
                //Magic String dediğimiz bir anti pattern var !!
                //Her yerde tekrarlarsın sonra projede standart olmayan mesajlar oluşur!!!
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            //return new Result(); //result sınıfını newledik ama propertyleri set etmedik
            return new SuccessResult(Messages.ProductAdded); // bunu yapabilmenin yolu constructor a parametre göndermekten geçiyor

        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}


            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            //predicate p => p
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}

using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //loosely coupled --
        IProductDal _productDal; // bunların karşılığı nedir i biz dependencyresolvers da tanımlayacağız
        //ICategoryDal _categoryDal;
        ICategoryService _categoryService;

        //**** bir entitiy manager kendisi hariç başka dal ı enjekte edemez !!!

        //ILogger _logger;

        public ProductManager(IProductDal productDal/*, ILogger logger*/,ICategoryService categoryService)
        {
            _productDal = productDal;
            //_logger = logger;
            _categoryService = categoryService;//kategory service i entegre ettik
        }
        //loosely coupled --

        //Claim(iddia etmek demek)
        //[CacheAspect]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]//add methodunu doğrula productValidator a göre !!
        public IResult Add(Product product)
        {
            //log u başta çalıştırdık.
            //_logger.Log();

            //try
            //{
            //    //business codes

            //    _productDal.Add(product);

            //    return new SuccessResult(Messages.ProductAdded);

            //}
            //catch (Exception exception)
            //{
            //    _logger.Log();
            //}
            //return new ErrorResult();



            //business codes
            //validation bu kodlar birbirinden ayrı olmalı

            //fluent validation da yazdık bu kodları o yüzden commentliyorum
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid)
            //    //return new ErrorResult(" ");
            //}

            //core a aktarıyoruz ı yüzden kestik
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context); //ProductValiidator'u kullanarak ilgili sonuca ulas.
            //if (!result.IsValid) //Eger sonuc gecerli degilse hata firlat.
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //ValidationTool.Validate(new ProductValidator(), product);

            /*
             * loglama
             * cacheremove
             * performans
             * transaction

                bunlara öyle bir yapı kuracağız ki otomatik olacak.
             */
            //iş kuralı yazacağız -- business codes

            //aynı isimde ürün eklenemez !!

            //İş kurallarını iş motoru ile yazdık !!

            //workshop 3 Yeni kural :
            //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.

            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success /*&& Veya and kullanırız. */ )
            //{
            //    //nested if kullanmak iş kurallarını yazarken daha kullanışlı.
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {

            //        _productDal.Add(product);

            //        return new SuccessResult(Messages.ProductAdded);


            //    }

            //}

            //return new ErrorResult();


            //result is a new result
            //Result result = new Result();

            //fluent validation ile yazıldı !! commited
            //if (product.ProductName.Length < 2)
            //{
            //    //Magic String dediğimiz bir anti pattern var !!
            //    //Her yerde tekrarlarsın sonra projede standart olmayan mesajlar oluşur!!!
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //return new Result(); //result sınıfını newledik ama propertyleri set etmedik
            //return new SuccessResult(Messages.ProductAdded); // bunu yapabilmenin yolu constructor a parametre göndermekten geçiyor

        }

        [CacheAspect] //key,value //InMemeoryCache kullanacağız
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {

            //İş kurallarını 
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
            //throw new NotImplementedException();
        }

        //iş kodu parçacığı
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {

            //Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //varsa true yoksa false döndürür

            if (result) //result == true aynı
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }        

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }



    }
}

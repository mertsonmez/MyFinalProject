using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Global variable - global değişken 
        //Naming convension
        //Şuanlık veri tabanımız bu liste !!
        List<Product> _products;

        //Bellekte referans aldığımız zaman çalışacak blok...
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ ProductId = 1 , CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product{ ProductId = 2 , CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product{ ProductId = 3 , CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product{ ProductId = 4 , CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product{ ProductId = 5 , CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ ile liste bazlı yapıları sql gibi sorgulayabiliyoruz.

            //1.Way 

            //Product productToDelete = null;
            //tek tek elimdeki liste elemanlarını dolaşıyorum eğer id si 
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //genellikle id olan sorgularda biz bunu kullanırız. firstOrDefault da kullanılabilir.
            //Lambda =>
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//SingleOrDefault tek bir eleman bulmaya yarar. her bir p için tek tek dolaşıyor.


            _products.Remove(productToDelete);


        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id sine sahip olan listedeki ürünü bul demek !!
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//SingleOrDefault tek bir eleman bulmaya yarar. her bir p için tek tek dolaşıyor.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}

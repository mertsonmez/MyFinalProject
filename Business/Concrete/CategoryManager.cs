using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //bağımlılığı constructor injection ile yapıyorum.


        //public List<Category> GetAll()
        //{
        //    //İş kodları
        //    return _categoryDal.GetAll();
        //}

        //select * from Categories where CategoryId = categoryId(yeni Id yi ne gönderirsen)
        //public Category GetById(int categoryId)
        //{
        //    return _categoryDal.Get(c => c.CategoryId == categoryId);
        //}

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId == categoryId));
        }
    }
}

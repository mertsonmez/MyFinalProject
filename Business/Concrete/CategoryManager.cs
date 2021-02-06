using Business.Abstract;
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


        public List<Category> GetAll()
        {
            //İş kodları
            return _categoryDal.GetAll();
        }

        //select * from Categories where CategoryId = categoryId(yeni Id yi ne gönderirsen)
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}

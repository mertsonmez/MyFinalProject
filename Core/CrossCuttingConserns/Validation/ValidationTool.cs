using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConserns.Validation
{
    public static class ValidationTool // bu tür araçlar statik oluşturulur genellikle...
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator();
            var result = validator.Validate(context); //ProductValiidator'u kullanarak ilgili sonuca ulas.
            if (!result.IsValid) //Eger sonuc gecerli degilse hata firlat.
            {
                throw new ValidationException(result.Errors);
            }

            //evrensel klullanmılabilir bir hale getireceğiz kodu 
        }
    }
}

using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflection --> çalışma anında birşeyleri çalıştırabilmemizi sağlıyor!! Activator.CreateInstance
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //productValidatorun(onu gönderdiğimiz için) çalışma tipini bul diyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //parametrelerini bul --> ilgili methodun parametrelerini
            //!!! invocation method demek !!!
            //validatorun tipine eşit olan parametreleri git bul diyor !!
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //her birini tek tek gez validationTool u kullanarak validate et !!!
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

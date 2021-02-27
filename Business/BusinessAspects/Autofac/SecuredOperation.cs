using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // metni senin belittiğin karaktere göre ayırıp array e atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation) //MethodInterception dan geliyo bu method
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))//claimlerinin içinde ilgili role varsa return et
                {
                    return;
                }
            }//eğer yoksa yetkin yok hatası ver
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}

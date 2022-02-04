using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspect.Autofac
{

    //bu sınıf add metodu önüne eklediğimiz aspect security için.
    public class SecuredOperation : MethodInterception
    {
        //attribute olduğu için aspect içine virgül ile gönderilecek şeyler giriliyor.
        private string[] _roles;
        //istek gönderen her kişi için bir http context oluşur.
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //burada gönderilen rollar virgül ile string şeklinde gönderildiği için virgüllerden ayırıyoruz genel stringi.
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //aspect  add den vs önce çalışsın diye fonksiyon.
        protected override void OnBefore(IInvocation invocation)
        {
            //kullanıcının rollerini kontrol et  eğer giriş izni varsa döndür yoksa hata ver diyor.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Yetki yok");
        }
    }
}

using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.BusinessLayer.Constants;
using NorthwindBackend.CoreLayer.Extensions;
using NorthwindBackend.CoreLayer.Utilities.Interceptors;
using NorthwindBackend.CoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (!roleClaims.Contains(role))
                {
                    throw new Exception(Messages.AuthorizationDenied);
                }
            }
            return;
        }
    }
}

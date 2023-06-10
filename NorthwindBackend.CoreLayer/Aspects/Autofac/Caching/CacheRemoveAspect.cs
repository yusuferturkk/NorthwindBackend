using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.CoreLayer.CrossCuttingConcerns.Caching;
using NorthwindBackend.CoreLayer.Utilities.Interceptors;
using NorthwindBackend.CoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CoreLayer.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}

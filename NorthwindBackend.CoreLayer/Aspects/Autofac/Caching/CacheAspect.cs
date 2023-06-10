using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.CoreLayer.CrossCuttingConcerns.Caching;
using NorthwindBackend.CoreLayer.Utilities.Interceptors;
using NorthwindBackend.CoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindBackend.CoreLayer.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private int _duration;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}

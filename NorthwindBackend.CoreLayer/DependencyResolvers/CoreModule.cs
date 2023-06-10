using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NorthwindBackend.CoreLayer.CrossCuttingConcerns.Caching;
using NorthwindBackend.CoreLayer.CrossCuttingConcerns.Caching.Microsoft;
using NorthwindBackend.CoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NorthwindBackend.CoreLayer.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}

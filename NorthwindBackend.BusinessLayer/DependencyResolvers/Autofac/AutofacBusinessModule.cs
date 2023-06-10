using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NorthwindBackend.BusinessLayer.Abstract;
using NorthwindBackend.BusinessLayer.Concrete;
using NorthwindBackend.CoreLayer.Utilities.Interceptors;
using NorthwindBackend.CoreLayer.Utilities.Security.Jwt;
using NorthwindBackend.DataAccessLayer.Abstract;
using NorthwindBackend.DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

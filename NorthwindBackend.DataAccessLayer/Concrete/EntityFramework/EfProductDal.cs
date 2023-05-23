using NorthwindBackend.CoreLayer.DataAccess.EntityFramework;
using NorthwindBackend.DataAccessLayer.Abstract;
using NorthwindBackend.DataAccessLayer.Concrete.Context;
using NorthwindBackend.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}

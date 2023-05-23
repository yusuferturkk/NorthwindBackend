using NorthwindBackend.CoreLayer.DataAccess;
using NorthwindBackend.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericRepository<Product>
    {
    }
}

using NorthwindBackend.CoreLayer.Utilities.Results;
using NorthwindBackend.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategoryId(int categoryId);

        IResult TransactionalOperation(Product product);
    }
}

using NorthwindBackend.BusinessLayer.Abstract;
using NorthwindBackend.BusinessLayer.BusinessAspects.Autofac;
using NorthwindBackend.BusinessLayer.Constants;
using NorthwindBackend.BusinessLayer.ValidationRules.FluentValidation;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Caching;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Exception;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Logging;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Performance;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Transaction;
using NorthwindBackend.CoreLayer.Aspects.Autofac.Validation;
using NorthwindBackend.CoreLayer.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using NorthwindBackend.CoreLayer.Utilities.Business;
using NorthwindBackend.CoreLayer.Utilities.Results;
using NorthwindBackend.DataAccessLayer.Abstract;
using NorthwindBackend.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NorthwindBackend.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductNameExists(product.ProductName),
                CheckIfCategoryIsEnabled());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.AddedProduct);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(x => x.ProductName == productName) != null)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if (result.Data.Count <= 10)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.DeletedProduct);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id));
        }

        //[SecuredOperation("Product.List,Admin")]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList());
        }

        [PerformanceAspect(interval: 1)]
        [CacheAspect(duration: 10)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId));
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.UpdatedProduct);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.UpdatedProduct);
        }
    }
}

using NorthwindBackend.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindBackend.CoreLayer.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
    }
}

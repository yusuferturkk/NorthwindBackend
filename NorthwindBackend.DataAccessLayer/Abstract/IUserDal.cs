using NorthwindBackend.CoreLayer.DataAccess;
using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}

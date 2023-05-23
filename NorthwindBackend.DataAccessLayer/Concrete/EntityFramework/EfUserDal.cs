using NorthwindBackend.CoreLayer.DataAccess.EntityFramework;
using NorthwindBackend.DataAccessLayer.Abstract;
using NorthwindBackend.DataAccessLayer.Concrete.Context;
using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name,
                             };
                return result.ToList();
            }
        }
    }
}

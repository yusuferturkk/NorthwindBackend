using NorthwindBackend.CoreLayer.Utilities.Results;
using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}

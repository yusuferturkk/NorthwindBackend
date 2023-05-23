using NorthwindBackend.BusinessLayer.Abstract;
using NorthwindBackend.BusinessLayer.Constants;
using NorthwindBackend.CoreLayer.Utilities.Results;
using NorthwindBackend.DataAccessLayer.Abstract;
using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}

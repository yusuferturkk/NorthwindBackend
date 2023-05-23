using NorthwindBackend.CoreLayer.Entities.Concrete;
using NorthwindBackend.CoreLayer.Utilities.Results;
using NorthwindBackend.CoreLayer.Utilities.Security.Jwt;
using NorthwindBackend.EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

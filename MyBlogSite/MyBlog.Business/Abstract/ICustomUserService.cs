using MyBlog.Entities.Concrete.CustomIdentity;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface ICustomUserService
    {
        CustomIdentityUser GetCurrentUser();
        bool UserRegister(UserDto userInfo);


    }
}

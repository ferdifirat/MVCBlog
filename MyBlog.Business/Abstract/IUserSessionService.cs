using MyBlog.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface IUserSessionService
    {
        string GetRole();
        string GetEmail();
        string GetUserName();
        string GetUserId();
        Claim[] GetClaims(CustomIdentityUser user);
    }
}

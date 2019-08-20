using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete.CustomIdentity;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Abstract
{
   public interface IApplicationUserDal : IEntityRepository<CustomIdentityUser>
    {
        List<UserDto> GetUsersWithUserRoles();

    }
}

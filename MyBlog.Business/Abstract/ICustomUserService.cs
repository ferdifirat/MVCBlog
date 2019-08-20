using MyBlog.Entities.Concrete.CustomIdentity;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface ICustomUserService
    {
        CustomIdentityUser GetCurrentUser();
        bool UserRegister(UserDto userInfo);
        List<UserDto> GetUsersWithUserRoles();
        /*Task<List<CustomIdentityUser>> GetUsersAsync();*/

    }
}

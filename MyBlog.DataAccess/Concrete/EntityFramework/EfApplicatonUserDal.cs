using Microsoft.EntityFrameworkCore;
using MyBlog.Core.DataAccess.EntityFramework;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete.CustomIdentity;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFramework
{
    public class EfApplicatonUserDal : EfRepositoryBase<CustomIdentityUser>, IApplicationUserDal
    {
        public EfApplicatonUserDal(DbContext dbContext) : base(dbContext)
        {

        }

        public List<UserDto> GetUsersWithUserRoles()
        {
            var result = new List<UserDto>();

            using (var context = new MyBlogDbContext())
            {



            }



            return result;
        }
    }
}

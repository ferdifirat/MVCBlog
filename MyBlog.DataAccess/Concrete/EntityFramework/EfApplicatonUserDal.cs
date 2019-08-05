using Microsoft.EntityFrameworkCore;
using MyBlog.Core.DataAccess.EntityFramework;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete.CustomIdentity;
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
          
    }
}

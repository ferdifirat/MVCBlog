using Microsoft.EntityFrameworkCore;
using MyBlog.Core.DataAccess.EntityFramework;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFramework
{
    public class EfTagDal : EfRepositoryBase<Tag>, ITagDal
    {

        public EfTagDal(DbContext dbContext) : base(dbContext)
        {

        }

    }
}

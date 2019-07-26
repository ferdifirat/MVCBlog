using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        //List<Post> GetListWithUserInformation(Expression<Func<Post, bool>> expression=null);
    }
}

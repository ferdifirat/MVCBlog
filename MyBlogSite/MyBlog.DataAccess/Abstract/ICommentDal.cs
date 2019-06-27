using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DataAccess.Abstract
{
   public interface ICommentDal : IEntityRepository<Comment>
    {
        List<Comment> GetListWithUserInformation(Expression<Func<Comment, bool>> expression);
        List<Comment> GetCommentListWithPostInformation(Expression<Func<Comment, bool>> expression);
    }
}

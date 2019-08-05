using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DataAccess.Abstract
{
   public interface ICommentDal : IEntityRepository<Comment>
    {
        List<CommentDto> GetListWithUserInformation(Expression<Func<Comment, bool>> expression);
        List<CommentDto> GetCommentListWithPostInformation(Expression<Func<Comment, bool>> expression);
        List<CommentDto> GetCommentsWithUserInformation();
    }
}

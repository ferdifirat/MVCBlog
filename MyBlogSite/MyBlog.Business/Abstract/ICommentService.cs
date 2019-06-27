using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MyBlog.Entities.Concrete;

namespace MyBlog.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList(Expression<Func<Comment,bool>> expression = null);
        List<Comment> GetListWithUserInformation(Expression<Func<Comment, bool>> expression);
        void AddComment(Comment comment);
        List<Comment> GetCommentsByCurrentUser();
        bool DeleteComment(int id);
    }
}

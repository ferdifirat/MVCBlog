using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;

namespace MyBlog.Business.Abstract
{
    public interface ICommentService
    {
        List<CommentDto> GetList(Expression<Func<Comment,bool>> expression = null);
        List<CommentDto> GetListWithUserInformation(Expression<Func<Comment, bool>> expression);
        void AddComment(CommentDto comment);
        List<CommentDto> GetCommentsByCurrentUser();
        bool DeleteComment(int id);
        List<CommentDto> GetCommentsWithUserInformation();
        bool UpdateComment(Expression<Func<Comment, bool>> expression);
    }
}

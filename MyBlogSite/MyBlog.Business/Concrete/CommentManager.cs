using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly ICustomUserService _customUserService;


        public CommentManager(ICustomUserService customUserService, ICommentDal commentDal)
        {
            _customUserService = customUserService;
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {
            comment.UserId = _customUserService.GetCurrentUser().Id;
            comment.CommentDate = DateTime.Now;
            comment.IsActive = true;
            _commentDal.Add(comment);  //Repository'ye gideceğiz..
            _commentDal.Save();
        }

        public bool DeleteComment(int id)
        {
            try
            {
                var comment = _commentDal.Get(x => x.Id == id);
                _commentDal.Delete(comment);
                _commentDal.Save();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }


        }

        public List<Comment> GetCommentsByCurrentUser()
        {

            return _commentDal.GetCommentListWithPostInformation(x => x.UserId == _customUserService.GetCurrentUser().Id);
        }

        public List<Comment> GetList(Expression<Func<Comment, bool>> expression = null)
        {
            return _commentDal.GetList(expression);
        }

        public List<Comment> GetListWithUserInformation(Expression<Func<Comment, bool>> expression)
        {
            return _commentDal.GetListWithUserInformation(expression);
        }
    }
}

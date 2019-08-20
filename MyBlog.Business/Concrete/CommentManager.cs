using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
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

        public void AddComment(CommentDto commentDto)
        {
            var addComment = new Comment()
            {
                UserId = _customUserService.GetCurrentUser().Id,
                CommentDate = DateTime.Now,
                IsActive = true,
                Content = commentDto.Content,  //TODO Kontrol
                PostId = commentDto.PostId
            };
            _commentDal.Add(addComment);
            _commentDal.Save();


            //commentDto.UserId = _customUserService.GetCurrentUser().Id;
            //commentDto.CommentDate = DateTime.Now;
            //commentDto.IsActive = true;
            //_commentDal.Add(commentDto);  //Repository'ye gideceğiz..
            //_commentDal.Save();
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

        public List<CommentDto> GetCommentsByCurrentUser()
        {
            var result = new List<CommentDto>();
            var getCommentsByCurretUser = _commentDal.GetCommentListWithPostInformation(x => x.UserId == _customUserService.GetCurrentUser().Id);

            foreach (var item in getCommentsByCurretUser)
            {
                var dtoComment = new CommentDto
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    IsActive = item.IsActive,
                    Id = item.Id,
                    PostId = item.PostId,
                    UserId = item.UserId
                };
            }


            return result;
        }


        public List<CommentDto> GetList(Expression<Func<Comment, bool>> expression = null)
        {
            var result = new List<CommentDto>();
            var getList = _commentDal.GetList(expression);

            foreach (var item in getList)
            {
                var dtoComment = new CommentDto()
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    PostId = item.PostId,
                    UserId = item.UserId
                };
            }
            return result;
        }

        public List<CommentDto> GetListWithUserInformation(Expression<Func<Comment, bool>> expression = null)
        {
            return  _commentDal.GetListWithUserInformation(expression);
        }


        public List<CommentDto> GetCommentsWithUserInformation()
        {
            return _commentDal.GetCommentsWithUserInformation();
        }

        public bool UpdateComment(Expression<Func<Comment, bool>> expression)
        {
            try
            {
                var comment = _commentDal.Get(expression);
                if (!comment.IsActive)
                    comment.IsActive = true;
                else
                    comment.IsActive = false;

                _commentDal.Update(comment);
                _commentDal.Save();

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}

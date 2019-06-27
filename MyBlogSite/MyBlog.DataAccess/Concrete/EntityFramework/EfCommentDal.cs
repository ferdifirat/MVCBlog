using Microsoft.EntityFrameworkCore;
using MyBlog.Core.DataAccess.EntityFramework;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfRepositoryBase<Comment>, ICommentDal
    {

        public EfCommentDal(DbContext dbContext) : base(dbContext)
        {

        }

        public List<Comment> GetCommentListWithPostInformation(Expression<Func<Comment, bool>> expression)
        {
            var result = new List<Comment>();
            using (var context = new MyBlogDbContext())
            {
                result = context.Comments.Include(x => x.Post).Where(expression).Select(item => new Comment()
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    Post = item.Post,
                    PostId = item.PostId,
                    UserId = item.UserId

                }).ToList();
            }


            return result;
        }

        public List<Comment> GetListWithUserInformation(Expression<Func<Comment, bool>> expression)
        {
            var result = new List<Comment>();

            using (var context = new MyBlogDbContext())
            {
                result = context.Comments.Include(x => x.AspNetUsers).Where(expression).Select(item => new Comment()
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    PostId = item.PostId,
                    AspNetUsers = item.AspNetUsers,
                    UserId = item.UserId
                }).ToList();
            }

            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyBlog.Core.DataAccess.EntityFramework;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
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

        public List<CommentDto> GetCommentListWithPostInformation(Expression<Func<Comment, bool>> expression)
        {
            var result = new List<CommentDto>();
            using (var context = new MyBlogDbContext())
            {
                result = context.Comments.Include(x => x.Post).Where(expression).Select(item => new CommentDto()
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    PostId = item.PostId,
                    UserId = item.UserId,
                    PostCommentDto = new PostCommentDto
                    {
                        Id=item.Post.Id,
                        Title=item.Post.Title
                    },
                    UserCommentDto=new UserCommentDto
                    {
                        Id=item.AspNetUsers.Id,
                        CitizenshipNumber=item.AspNetUsers.CitizenshipNumber,
                        Email=item.AspNetUsers.Email,
                        FirstName=item.AspNetUsers.FirstName
                    }
                    

                }).ToList();
            }


            return result;
        }

        public List<CommentDto> GetListWithUserInformation(Expression<Func<Comment, bool>> expression)
        {
            var result = new List<CommentDto>();

            using (var context = new MyBlogDbContext())
            {
                result = context.Comments.Include(x => x.AspNetUsers).Select(item => new CommentDto()
                {
                    CommentDate = item.CommentDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    PostId = item.PostId,
                    UserId = item.UserId,
                    UserCommentDto=new UserCommentDto()
                    {
                        Id=item.AspNetUsers.Id,
                        FirstName=item.AspNetUsers.FirstName,
                        Email=item.AspNetUsers.Email,
                        CitizenshipNumber=item.AspNetUsers.CitizenshipNumber
                    }
                }).ToList();
            }

            return result;
        }


        public List<CommentDto> GetCommentsWithUserInformation()
        {
            var result = new List<CommentDto>();
            
            using (var context = new MyBlogDbContext())
            {
                result = context.Comments.Include(x => x.Post).Include(x=>x.AspNetUsers).Select(item => new CommentDto()
                {
                    //AspNetUsers=item.AspNetUsers,    //TODO EKLENECEK:
                    //Post=item.Post,
                    CommentDate=item.CommentDate,
                    Content=item.Content,
                    Id=item.Id,
                    IsActive=item.IsActive,
                    UserCommentDto=new UserCommentDto()
                    {
                        CitizenshipNumber=item.AspNetUsers.CitizenshipNumber,
                        Email=item.AspNetUsers.Email,
                        FirstName=item.AspNetUsers.FirstName,
                        Id=item.AspNetUsers.Id
                    },
                    PostCommentDto=new PostCommentDto()
                    {
                        Id=item.Post.Id,
                        Title=item.Post.Title
                    }
                    
                    
                }).ToList();
                 
            }

            return result;
        }
        
    }
}

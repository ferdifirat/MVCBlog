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
    public class EfPostDal : EfRepositoryBase<Post>, IPostDal
    {
        public EfPostDal(DbContext dbContext) : base(dbContext)
        {
         

        }

        public List<PostDto> GetPostsWithUserInformation()
        {
            var result = new List<PostDto>();

            using (var context = new MyBlogDbContext())
            {
                result = context.Posts.Include(y => y.Category).Include(x => x.AspNetUsers).Select(item => new PostDto {
                    CreationDate = item.CreationDate,
                    Content = item.Content,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    Title = item.Title,
                    ReadCount = item.ReadCount,
                    Voting = item.Voting,
                    PostsUser = new PostsUserDto()
                    {
                        Id = item.AspNetUsers.Id,
                        UserName = item.AspNetUsers.UserName
                    },
                    Category = new CategoryDto()
                    {
                        CategoryName = item.Category.CategoryName,
                        Id = item.Category.Id,
                        ParentCategoryId = item.Category.ParentCategoryId
                    },
                    CategoryId = item.CategoryId,
                    
                }).ToList();
            }

            return result;
        }
    }
}

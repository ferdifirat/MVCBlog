using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        List<PostDto> GetPostsWithUserInformation();
    }
}

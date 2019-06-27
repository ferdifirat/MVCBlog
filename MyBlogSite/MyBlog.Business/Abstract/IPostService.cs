using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface IPostService
    {
        Post GetPost(Expression<Func<Post, bool>> expression);
        List<Post> GetPosts(Expression<Func<Post, bool>> expression = null);
        bool AddPost(Post post);
        List<Post> GetPostByCurrentUser();
        bool UpdatePost(Post post);
        bool DeletePost(int id);
    }
}

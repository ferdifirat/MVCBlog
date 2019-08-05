using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface IPostService
    {
        PostDto GetPost(Expression<Func<Post, bool>> expression);
        List<PostDto> GetPosts(Expression<Func<Post, bool>> expression = null);
        bool AddPost(PostDto post);
        List<PostDto> GetPostByCurrentUser();
        bool UpdatePost(PostDto post);
        bool DeletePost(int id);
        //List<Post> GetListWithUserInformation(Expression<Func<Post, bool>> expression=null);
        bool UpdatePost(Expression<Func<Post, bool>> expression);
        List<PostDto> GetPostsWithUserInformation();
    }
}

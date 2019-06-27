using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private readonly ICustomUserService _customUserService;

        public PostManager(
            IPostDal postDal,
            ICustomUserService customUserService
            )
        {
            _customUserService = customUserService;
            _postDal = postDal;
        }

        public bool AddPost(Post post)
        {
            try
            {
                post.CreationDate = DateTime.Now;
                post.UserId = _customUserService.GetCurrentUser().Id;
                post.IsActive = true;

                _postDal.Add(post);
                _postDal.Save();

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
           
        }

        public bool UpdatePost(Post post)
        {
            try
            {
                post.CreationDate = DateTime.Now;
                post.UserId = _customUserService.GetCurrentUser().Id;
                
                _postDal.Update(post);
                _postDal.Save();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }



        public Post GetPost(Expression<Func<Post, bool>> expression)
        {
            return _postDal.Get(expression);
        }

        public List<Post> GetPostByCurrentUser()
        {
            var currentUser = _customUserService.GetCurrentUser();
            return _postDal.GetList(x => x.UserId == currentUser.Id);
        }

        public List<Post> GetPosts(Expression<Func<Post, bool>> expression = null)
        {
            return _postDal.GetList(expression);
        }

        public bool DeletePost(int id)
        {
            try
            {
                var post = _postDal.Get(x => x.Id == id);
                _postDal.Delete(post);
                _postDal.Save();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}

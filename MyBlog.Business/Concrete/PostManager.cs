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

        public bool AddPost(PostDto postDto)
        {
            try
            {
                var post = new Post()
                {
                    CreationDate = postDto.CreationDate,
                    IsActive = postDto.IsActive,
                    UserId = _customUserService.GetCurrentUser().Id
                };

                _postDal.Add(post);
                _postDal.Save();

                return true;
            }
            catch (Exception exp)
            {

                return false;
            }

        }

        public bool UpdatePost(PostDto postDto)
        {
            try
            {
                var post = new Post
                {
                    CreationDate = postDto.CreationDate,
                    UserId = _customUserService.GetCurrentUser().Id
                };

                _postDal.Update(post);
                _postDal.Save();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }



        public PostDto GetPost(Expression<Func<Post, bool>> expression)
        {
            var getPosts = _postDal.Get(expression);

            var dtoPost = new PostDto()
            {
                Content = getPosts.Content,
                CategoryId = getPosts.CategoryId,
                CreationDate = getPosts.CreationDate,
                IsActive = getPosts.IsActive,
                Picture = getPosts.Picture,
                ReadCount = getPosts.ReadCount,
                Summary = getPosts.Summary,
                Title = getPosts.Title,
                Voting = getPosts.Voting,
                Id = getPosts.Id,
            };

            return dtoPost;
        }

        public List<PostDto> GetPostByCurrentUser()
        {
            var result = new List<PostDto>();
            var currentUser = _customUserService.GetCurrentUser();

            var posts = _postDal.GetList(x => x.UserId == currentUser.Id);

            foreach (var item in posts)
            {
                var post = new PostDto()
                {
                    Content = item.Content,
                    IsActive = item.IsActive,
                    Id = item.Id,
                    Summary = item.Summary
                };
                result.Add(post);

            }

            return result;
        }

        public List<PostDto> GetPosts(Expression<Func<Post, bool>> expression = null)
        {
            var result = new List<PostDto>();
            var posts = _postDal.GetList(expression);

            foreach (var item in posts)
            {
                var post = new PostDto()
                {
                    Id=item.Id,
                    CategoryId = item.CategoryId,
                    Content = item.Content,
                    CreationDate = item.CreationDate,
                    IsActive = item.IsActive,
                    Picture = item.Picture,
                    ReadCount = item.ReadCount,
                    Summary = item.Summary,
                    Title = item.Title,
                    Voting = item.Voting,
                };
                result.Add(post);
            }


            return result;
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

        public bool UpdatePost(Expression<Func<Post, bool>> expression)
        {
            try
            {
                var post = _postDal.Get(expression);
                if (post.IsActive == true)
                    post.IsActive = false;
                else
                    post.IsActive = true;

                _postDal.Update(post);
                _postDal.Save();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public List<PostDto> GetPostsWithUserInformation()
        {
            return _postDal.GetPostsWithUserInformation();
        }


    }
}

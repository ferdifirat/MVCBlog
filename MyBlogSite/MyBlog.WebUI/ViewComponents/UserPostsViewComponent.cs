using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebUI.ViewComponents
{
    public class UserPostsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;


        public UserPostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new PostsViewModel();
            model.Posts = _postService.GetPostByCurrentUser();
            return View(model);
        }
    }
}

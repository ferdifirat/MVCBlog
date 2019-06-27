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
    public class LatestPostViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public LatestPostViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public ViewViewComponentResult Invoke(int postId)
        {
            var model = new PostsViewModel();
            model.Posts = _postService.GetPosts().OrderByDescending(x => x.Id).Take(10).ToList();
            return View(model);
        }
    }
}

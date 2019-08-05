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
    public class UserCommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public UserCommentViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }


       public ViewViewComponentResult Invoke()
        {
            var model = new CommentsViewModel();
            model.Comments = _commentService.GetCommentsByCurrentUser();
            return View(model);
        }
    }
}

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
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public ViewViewComponentResult Invoke(int postId)
        {
            var model = new CommentsViewModel();
            model.Comments = _commentService.GetListWithUserInformation(p=>p.PostId == postId);
            model.PostId = postId;
            return View(model);
        }
    }
}

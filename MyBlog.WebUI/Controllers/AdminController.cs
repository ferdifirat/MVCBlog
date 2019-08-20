using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels;
using MyBlog.Entities.Concrete.CustomIdentity;

namespace MyBlog.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ICustomUserService _customUserService;
        private readonly ICommentService _commentService;

        public AdminController(
            ICommentService commentService,
            ICustomUserService customUserService,
            IPostService postService,
            ICategoryService categoryService)
        {
            _commentService = commentService;
            _customUserService = customUserService;
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            var model = new CategoriesViewModel();
            model.Categories = _categoryService.GetList();
            return View(model);
        }

        public IActionResult CategoryDetail(int id)
        {
            var model = new CategoryViewModel();
            model.CategoryDto = _categoryService.GetCategory(x => x.Id == id);
            return View(model);
        }

        public IActionResult DeleteCategory(int id)
        {
            if (_categoryService.DeleteCategory(id))
            {
                return RedirectToAction("Categories", "Admin");
            }
            return View();
        }

        public IActionResult Posts()
        {
            var model = new PostsViewModel(); //sorulacak
            model.Posts = _postService.GetPostsWithUserInformation();
            return View(model);
        }

      

        [HttpPost]
        public IActionResult PostStatus(int id)
        {
            if (_postService.UpdatePost(x => x.Id == id))
            {
                return RedirectToAction("Posts", "Admin");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            if (_postService.DeletePost(id))
            {
                return RedirectToAction("Posts", "Admin");
            }
            return View();
        }

        
        public IActionResult PostDetail(int id)
        {
            var model = new PostViewModel();
            model.PostDto = _postService.GetPost(x => x.Id == id);
            return View(model);
         
        }



        public IActionResult Comments()
        {
            var model = new CommentsViewModel();
            model.Comments = _commentService.GetCommentsWithUserInformation();

            return View(model);
        }


        public IActionResult CommentStatus(int id)
        {
            if (_commentService.UpdateComment(x => x.Id == id)) 
            {
                return RedirectToAction("Comments", "Admin");
            }

            return View();
        }

        public IActionResult DeleteComment(int id)
        {
            if (_commentService.DeleteComment(id))
            {
                return RedirectToAction("Comments", "Admin");
            }

            return View();
        }

        public IActionResult Users()
        {
            var model = new UsersViewModel();
           
            // to do:
            return View(model);
        }



    }
}
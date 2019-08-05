using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels;
using MyBlog.Entities.Concrete;

namespace MyBlog.WebUI.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;


        public PostController(
            ICommentService commentService,
            ICategoryService categoryService,
            IPostService postService
            )
        {
            _commentService = commentService;
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult Index(int? categoryId = null)
        {
            var viewModel = new PostsViewModel();
            if (categoryId == null)
                viewModel.Posts = _postService.GetPosts();
            else
                viewModel.Posts = _postService.GetPosts(p => p.CategoryId == categoryId);

            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new PostViewModel();
            viewModel.Categories = _categoryService.GetCategoriesForCategoryComboBox();

            return View(viewModel);
        }
        [HttpPost]

        public IActionResult Add(PostViewModel viewModel)
        {

            if (_postService.AddPost(viewModel.PostDto))
            {
                
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Update(int postId)
        {
            var viewModel = new PostViewModel();
            viewModel.PostDto = _postService.GetPost(x => x.Id == postId);
            viewModel.Categories = _categoryService.GetCategoriesForCategoryComboBox();
            
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(PostViewModel viewModel)
        {

           if (_postService.UpdatePost(viewModel.PostDto))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
       
        public IActionResult Delete(int id)
        {
            if (_postService.DeletePost(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Detail(int id)
        {
            var viewModel = new PostViewModel();
            viewModel.PostDto = _postService.GetPost(p => p.Id == id);
            return View(viewModel);
        }

        public IActionResult AddComment(CommentsViewModel viewModel)
        {
            _commentService.AddComment(viewModel.CommentDto);
            
            return RedirectToAction("Detail", new { id = viewModel.CommentDto.PostId });
        }

        public IActionResult DeleteComment(int id)
        {
            if (_commentService.DeleteComment(id))
            {
                return RedirectToAction("Profile","Account");
            }
            return View();
        }
    }
}
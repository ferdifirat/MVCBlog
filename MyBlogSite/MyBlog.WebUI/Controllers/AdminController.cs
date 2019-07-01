using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels;

namespace MyBlog.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminController(ICategoryService categoryService)
        {
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
            model.Category = _categoryService.GetCategory(x => x.Id == id);
            return View(model);
        }
    }
}
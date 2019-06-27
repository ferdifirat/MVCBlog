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
    public class CategoryListViewComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public CategoryListViewComponent(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoriesViewModel();
            model.Categories = _categoryService.GetList();
            return View(model);
        }
    }
}

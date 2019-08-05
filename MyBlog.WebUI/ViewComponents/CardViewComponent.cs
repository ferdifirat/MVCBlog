using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebUI.ViewComponents
{
    public class CardViewComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;
        public CardViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CardViewModel();
            model.Categories = _categoryService.GetList(p => p.ParentCategoryId == null);
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyBlog.DataAccess.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebUI.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {

        public CarouselViewComponent()
        {
           
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CarouselViewModel();
           
            return View(model);
        }
    }
}

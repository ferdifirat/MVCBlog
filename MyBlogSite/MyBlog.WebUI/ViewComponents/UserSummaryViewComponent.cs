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
    public class UserSummaryViewComponent : ViewComponent
    {
        
        private readonly ICustomUserService _customUserService;

        public UserSummaryViewComponent(
            ICustomUserService customUserService)
        {
            _customUserService = customUserService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new UserSummaryViewModel();
            var user = _customUserService.GetCurrentUser();
            model.FullName = user.FirstName + " " + user.Surname;
            return View(model);
        }
    }
}

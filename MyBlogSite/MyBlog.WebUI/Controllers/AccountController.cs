using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.ViewModels;
using MyBlog.Entities.Concrete.CustomIdentity;

namespace MyBlog.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ICustomUserService _customUserService;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly UserManager<CustomIdentityUser> _userManager;


        public AccountController(
        UserManager<CustomIdentityUser> userManager,

        ICustomUserService customUserService,
            SignInManager<CustomIdentityUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customUserService = customUserService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.EmailAddress,
                    loginViewModel.Password, loginViewModel.RememberMe, true).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }


        public ActionResult Profile()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();


            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            var result = _customUserService.UserRegister(registerViewModel.UserInfo);

            if (!result)
            {
                return View(registerViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword()
        {
            var changePasswordViewModel = new ChangePasswordViewModel()
            {
                UserName = _customUserService.GetCurrentUser().UserName
            };
            return View(changePasswordViewModel);
        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var customUser = _customUserService.GetCurrentUser();
            var updatedPassword = _userManager.ChangePasswordAsync(customUser, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword).Result;
            if (updatedPassword.Succeeded)
            {
                return RedirectToAction("Profile");
            }
            return View(changePasswordViewModel);
        }

    }
}
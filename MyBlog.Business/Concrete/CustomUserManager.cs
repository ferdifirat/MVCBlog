using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFramework;
using MyBlog.Entities.Concrete.CustomIdentity;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
    public class CustomUserManager : ICustomUserService
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly HttpContext _context;
        private readonly IApplicationUserDal _applicationUserDal;

        public CustomUserManager(
            IApplicationUserDal applicationUserDal,
            UserManager<CustomIdentityUser> userManager,
            IHttpContextAccessor contextAccessor
            )
        {
            _applicationUserDal = applicationUserDal;
            _userManager = userManager;
            _context = contextAccessor.HttpContext;
        }

        public CustomIdentityUser GetCurrentUser()
        {
            var customIdentityUser = _userManager.FindByNameAsync(_context.User.Identity.Name).Result;

            //var result = new UserDto()
            //{
            //    Address=customIdentityUser.Address,
            //    Birthday=customIdentityUser.Birthday,
            //    CitizenshipNumber=customIdentityUser.CitizenshipNumber,
            //    ConcurrencyStamp=customIdentityUser.ConcurrencyStamp,
            //    Email=customIdentityUser.Email,
            //    FirstName=customIdentityUser.FirstName,
            //    Id=customIdentityUser.Id,
            //    PhoneNumber=customIdentityUser.PhoneNumber,
            //    SecurityStamp=customIdentityUser.SecurityStamp,
            //    Surname=customIdentityUser.Surname,
            //    Password=customIdentityUser.PasswordHash,
            //    ConfirmPassword=customIdentityUser.PasswordHash
            //};

            return customIdentityUser;
        }


        public bool UserRegister(UserDto user)
        {

            var customIdentityUser = new CustomIdentityUser()
            {
                Address = user.Address,
                Birthday = user.Birthday,
                CitizenshipNumber = user.CitizenshipNumber,
                Email = user.Email,
                FirstName = user.FirstName,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Email,
                Status = true,
            };

            var result = _userManager.CreateAsync(customIdentityUser, user.Password).Result;
            if (!result.Succeeded)
            {
                return false;
            }
            _userManager.AddToRoleAsync(customIdentityUser, "User").Wait();
            return true;
        }


        public List<UserDto> GetUsersWithUserRoles()
        {
            return null;
        }


        //public async Task<List<CustomIdentityUser>> GetUsersAsync()
        //{
        //    using (var context = new MyBlogDbContext())
        //    {
        //        return await _userManager.Users.ToListAsync();
        //    }
        //}

    }
}

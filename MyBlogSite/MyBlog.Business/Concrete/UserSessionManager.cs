using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyBlog.Business.Abstract;
using MyBlog.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyBlog.Business.Concrete
{
    public class UserSessionManager  : IUserSessionService
    {
        private HttpContext _httpContext;
        private readonly UserManager<CustomIdentityUser> _userManager;

        public string GetRole()
        {
            return GetClaimValue(ClaimTypes.Role);
        }

        public string GetEmail()
        {
            return GetClaimValue(ClaimTypes.Email);
        }

        public string GetUserName()
        {
            return GetClaimValue(ClaimTypes.Name);
        }

        public string GetUserId()
        {
            return GetClaimValue(ClaimTypes.NameIdentifier);
        }

        private string GetClaimValue(string type)
        {
            var user = _httpContext.User.Identities.FirstOrDefault();
            if (user == null)
                return string.Empty;

            var claim = user.Claims.FirstOrDefault(x => x.Type == type);

            if (claim == null)
                return string.Empty;

            return claim.Value;
        }

        public Claim[] GetClaims(CustomIdentityUser user)
        {
            var role = _userManager.GetRolesAsync(user).Result;
            var claims = new[]{
                    new Claim (ClaimTypes.NameIdentifier,user.Id),
                    new Claim (ClaimTypes.Email,user.Email),
                    new Claim (ClaimTypes.Name,user.UserName),
                    new Claim (ClaimTypes.Role,role.FirstOrDefault()),
            };

            return claims;
        }
    }
}

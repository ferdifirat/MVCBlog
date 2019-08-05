using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.Concrete.CustomIdentity
{
    public class CustomIdentityRole :  IdentityRole, IEntity
    {
        public CustomIdentityRole()
        {

        }
    }
}

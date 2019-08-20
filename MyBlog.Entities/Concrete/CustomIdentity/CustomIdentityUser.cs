using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.Concrete.CustomIdentity
{
    public class CustomIdentityUser : IdentityUser,IEntity
    {
        public CustomIdentityUser()
        {

        }
        
        public virtual string CitizenshipNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual bool? Status { get; set; }
        public virtual string Address { get; set; }

        
    }
}

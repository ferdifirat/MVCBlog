using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Identity_Entities
{
   public class IdentityDataContext : IdentityDbContext <ApplicationUser>
    {
        public IdentityDataContext() : base("identityConnection")
        {

        }
    }
}

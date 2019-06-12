using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
   public class User : IdentityUser
    {
        public virtual Member Member { get; set; }
        public virtual Manager Manager { get; set; }


    }
}

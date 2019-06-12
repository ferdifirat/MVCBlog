using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Identity_Entities
{
   public class ApplicationRole : IdentityRole
    {
    }
}

/*webconfig'e 
appsettings'in altın ADD KEY'lere
<add key="owin:AppStartup" value:"BlogProje.IdentityConfig"/> ekle */
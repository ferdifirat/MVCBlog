using BlogProje.DATA.Identity_Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
  public class Kullanici : IdentityUser
    {

        //TODO: Kullanıcı class'ı silinecek ApplicationUser içinde onun prop'larını yazdık...Ya oradan ApplicationUser'ı silip buraya direk oluşturmamız gerekiyor...2 yeere de IdentityUser miras verince çift Mapping yapıyor :)

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Photo { get; set; }

       // public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Article> Articles { get; set; }

      //  TODO: Maopping kontrol edilecek.

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Kullanici> manager)
        {
           // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
           var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //Add custom user claims here
            return userIdentity;
        }
    }
}

using DAL;
using DATA.Model_Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BlogSonUygulama.Controllers
{
    public class AApiController : ApiController
    {

        private readonly Context db;
        private readonly UserStore<Kullanici> uStore;
        private readonly UserManager<Kullanici> AppUserManager;


        public AApiController()
        {
            db = new Context();
            uStore = new UserStore<Kullanici>(db);
            AppUserManager = new UserManager<Kullanici>(uStore);
        }


        public UnrealUser GetUserByName(string username, string password)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            Kullanici user = AppUserManager.Find(username, password);

            if (user != null)
            {

                UnrealUser a = new UnrealUser()
                {
                    FirstName = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName,
                };

                return a;
            }

            return null;

        }

    }
    public class UnrealUser  //gerçek kullanıcı
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLink { get; set; }

    }
}
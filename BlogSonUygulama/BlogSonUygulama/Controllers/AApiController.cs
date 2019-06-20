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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlogProje.DATA.Model_Entities;

namespace BlogProjesi.DAL.Context
{
   public class Context : DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server =EREN\\SQLEXPRESS; database = BlogDb; trusted_connection=true";

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Tag> Tags { get; set; }


        
    }
    
}

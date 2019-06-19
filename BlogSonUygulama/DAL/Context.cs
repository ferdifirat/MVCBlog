using DAL.Mapping;
using DATA.Model_Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : IdentityDbContext
    {
        public static Context Create()
        {
            return new Context();
        }

        public Context() : base("server=.; database = BlogDb10; uid=sa; pwd=123")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ArticleMapping());
            modelBuilder.Configurations.Add(new ArticleTagMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CommentMapping());
            modelBuilder.Configurations.Add(new TagMapping());

            base.OnModelCreating(modelBuilder);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete;
using MyBlog.Core.DataAccess;
using MyBlog.Core.DataAccess.EntityFramework;
//using MyBlog.Core.DataAccess.UnitOfWork;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFramework;
using MyBlog.Entities.Concrete.CustomIdentity;

namespace MyBlog.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Sessions and Cookies

            services.Configure<CookiePolicyOptions>(options =>
                   {
                       options.CheckConsentNeeded = context => true;
                       options.MinimumSameSitePolicy = SameSiteMode.None;
                   });

            services.AddSession(o =>
            {
                o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                o.Cookie.Name = "MySite.Session";
                o.Cookie.HttpOnly = true;
                o.IdleTimeout = TimeSpan.FromHours(3);
            });

            #endregion

            #region DbContext Registrations

            services.AddTransient<DbContext, MyBlogDbContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EfRepositoryBase<>));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
           
            


            services.AddDbContext<CustomIdentityDbContext>(
                options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            //services.AddTransient<IUnitOfWork, efUnitOfWork>();


            #endregion


            #region Services Registrations

            services.AddScoped<ICustomUserService, CustomUserManager>();
            services.AddScoped<IApplicationUserDal, EfApplicatonUserDal>();
            //services.AddScoped<IUserSessionService, UserSessionManager>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IPostDal, EfPostDal>();
         
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            
           
            #endregion

            services.AddAuthorization();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}

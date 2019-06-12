using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogProjesi.Startup))]
namespace BlogProjesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

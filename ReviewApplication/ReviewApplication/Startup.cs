using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewApplication.Startup))]
namespace ReviewApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

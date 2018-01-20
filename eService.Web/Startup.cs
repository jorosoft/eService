using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eService.Web.Startup))]
namespace eService.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

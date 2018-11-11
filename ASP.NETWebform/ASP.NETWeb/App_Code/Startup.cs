using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.NetWeb.Startup))]
namespace ASP.NetWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

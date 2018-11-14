using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(commodity.Startup))]
namespace commodity
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Product.Startup))]
namespace Product
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

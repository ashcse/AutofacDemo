using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductManagement.Startup))]
namespace ProductManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

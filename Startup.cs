using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helper.Startup))]
namespace Helper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

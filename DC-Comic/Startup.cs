using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DC_Comic.Startup))]
namespace DC_Comic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

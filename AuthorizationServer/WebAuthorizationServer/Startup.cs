using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAuthorizationServer.Startup))]
namespace WebAuthorizationServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

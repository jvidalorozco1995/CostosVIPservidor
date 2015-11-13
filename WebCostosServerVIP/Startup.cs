using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCostosServerVIP.Startup))]
namespace WebCostosServerVIP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_self_service_system.Startup))]
namespace IT_self_service_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

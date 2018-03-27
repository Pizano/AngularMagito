using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecepecionMSW.Startup))]
namespace RecepecionMSW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCon.Startup))]
namespace GCon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

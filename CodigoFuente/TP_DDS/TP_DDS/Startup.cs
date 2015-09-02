using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP_DDS.Startup))]
namespace TP_DDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

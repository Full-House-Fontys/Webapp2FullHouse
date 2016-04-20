using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTS_4_Full_House.Startup))]
namespace PTS_4_Full_House
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

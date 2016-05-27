using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(defeaultTemplateASPTest.Startup))]
namespace defeaultTemplateASPTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

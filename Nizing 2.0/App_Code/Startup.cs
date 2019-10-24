using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nizing_2._0.Startup))]
namespace Nizing_2._0
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

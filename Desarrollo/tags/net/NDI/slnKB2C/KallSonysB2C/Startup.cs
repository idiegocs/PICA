using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KallSonysB2C.Startup))]
namespace KallSonysB2C
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

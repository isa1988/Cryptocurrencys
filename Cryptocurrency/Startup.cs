using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cryptocurrency.Startup))]
namespace Cryptocurrency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

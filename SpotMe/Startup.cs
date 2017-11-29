using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpotMe.Startup))]
namespace SpotMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeAmazingThings.Startup))]
namespace MakeAmazingThings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

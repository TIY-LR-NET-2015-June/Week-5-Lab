using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MikeIt.Startup))]
namespace MikeIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadIt.Startup))]
namespace ReadIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

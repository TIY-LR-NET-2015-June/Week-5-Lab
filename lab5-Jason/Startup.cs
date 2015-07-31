using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab5_Jason.Startup))]
namespace lab5_Jason
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

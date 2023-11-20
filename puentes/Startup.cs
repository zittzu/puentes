using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(puentes.Startup))]
namespace puentes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

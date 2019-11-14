using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gemma.Startup))]
namespace Gemma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassicalMusicApp.Startup))]
namespace ClassicalMusicApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eLibrary_project.Startup))]
namespace eLibrary_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

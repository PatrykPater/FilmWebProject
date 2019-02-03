using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmWebProject.Startup))]
namespace FilmWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

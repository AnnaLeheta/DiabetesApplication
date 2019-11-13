using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiabetesProject.Startup))]
namespace DiabetesProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolManagingSystem.Startup))]
namespace SchoolManagingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikAcademy.FinalProject.Web.Startup))]
namespace TelerikAcademy.FinalProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

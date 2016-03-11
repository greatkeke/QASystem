using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QASystem.Web.Startup))]
namespace QASystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

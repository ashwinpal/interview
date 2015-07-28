using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(intelex_interview.Startup))]
namespace intelex_interview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

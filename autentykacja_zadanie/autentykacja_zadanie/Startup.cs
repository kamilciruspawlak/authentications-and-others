using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(autentykacja_zadanie.Startup))]
namespace autentykacja_zadanie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

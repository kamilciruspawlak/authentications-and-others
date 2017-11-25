using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(autentykacja.Startup))]
namespace autentykacja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

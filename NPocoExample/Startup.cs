using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NPocoExample.Startup))]
namespace NPocoExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

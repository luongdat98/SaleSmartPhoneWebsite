using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_phone.Startup))]
namespace my_phone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

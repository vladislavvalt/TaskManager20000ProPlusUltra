using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskManager20000ProPlusUltra.Startup))]

namespace TaskManager20000ProPlusUltra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GPA_TOOL_FINAL.Startup))]
namespace GPA_TOOL_FINAL
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

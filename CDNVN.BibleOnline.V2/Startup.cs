using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDNVN.BibleOnline.V2.Startup))]
namespace CDNVN.BibleOnline.V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiemCong_TranThanhPhong.Startup))]
namespace DiemCong_TranThanhPhong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using IocContainer.Containers;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(IocContainer.MvcExample.Startup))]
namespace IocContainer.MvcExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}

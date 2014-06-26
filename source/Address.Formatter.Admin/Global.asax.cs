using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using Address.Formatter.Admin.Configuration;
using Castle.Windsor;

namespace Address.Formatter.Admin
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.Init(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Init);
            WindsorConfig.Init(new WindsorContainer(), GlobalConfiguration.Configuration);
        }
    }
}
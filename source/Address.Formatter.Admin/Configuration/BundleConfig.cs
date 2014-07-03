using System.Web.Optimization;

namespace Address.Formatter.Admin.Configuration

{
    public static class BundleConfig
    {
        public static void Init(BundleCollection bundles)
        {
            bundles
                .Add(new ScriptBundle("~/bundles/modernizr")
                         .Include("~/Scripts/modernizr-*")
                );

            bundles
                .Add(new StyleBundle("~/bundles/style")
                         .Include("~/Content/bootstrap.css")
                         .Include("~/Content/site.css")
                );

            bundles.Add(
                new ScriptBundle("~/bundles/script")
                    .Include("~/Scripts/angular.js")
                    .Include("~/Scripts/angular-resource.js")
                // .Include("~/Scripts/angular-touch.js")
                    .Include("~/Scripts/angular-cookies.js")
                   // .Include("~/Scripts/angular-animate.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js")
                    .Include("~/Scripts/angularUI/ui-router.js")
                    .Include("~/Scripts/angular-draganddrop.js")
                    .Include("~/Client/App.js")
                    .IncludeDirectory("~/Client", "*.js", true)
                );
        }
    }
}
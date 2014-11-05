using System.Web;
using System.Web.Optimization;

namespace MedTech.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*",
                                                                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/App/Lib/angular.js",
                                                                      "~/Scripts/App/Lib/angular-animate.js",
                                                                      "~/Scripts/App/Lib/angular-cookies.js",
                                                                      "~/Scripts/App/Lib/angular-resource.js",
                                                                      "~/Scripts/App/Lib/angular-sanitize.js",
                                                                      "~/Scripts/App/Lib/angular-route.js",
                                                                      "~/Scripts/App/Lib/angular-messages.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.cerulean.css", 
                                                                 "~/Content/site.css"));
        }
    }
}
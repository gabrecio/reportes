using System.Web.Optimization;

namespace ERP.Reports.Api
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/json-viewer").Include(
                  "~/Scripts/jquery.json-viewer/json-viewer/jquery.json-viewer.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/bootstrap/dist/css/bootstrap.min.css",
                      "~/Scripts/jquery.json-viewer/json-viewer/jquery.json-viewer.css",
                      "~/Content/site.css"));
        }
    }
}

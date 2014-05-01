using System.Web;
using System.Web.Optimization;

namespace ParcelViewer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/content/css/datatables").Include(
                "~/Scripts/DataTables-1.10.0-rc.1/extensions/Bootstrap3/css/datatables.css",
                "~/Scripts/DataTables-1.10.0-rc.1/extensions/Bootstrap3/css/datatables.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/DataTables-1.10.0-rc.1/media/js/jquery.dataTables.js",
                "~/Scripts/DataTables-1.10.0-rc.1/extensions/Bootstrap3/js/datatables.js"));
        }

    }
}

using System.Web;
using System.Web.Optimization;

namespace HospitalManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-3.6.0.min.js",
                        "~/Scripts/jquery-ui-1.13.2.min.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/CustomTasks.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/DataTables/css/dataTables.bootstrap.css",
                        "~/Content/themes/base/jquery-ui.min.css"
                      ));
        }
    }
}

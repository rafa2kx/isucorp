using System.Web.Optimization;

namespace IsuCorpRound3
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-3.4.0.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/editor.js"));
            bundles.Add(new ScriptBundle("~/bundles/create").Include(
                "~/Scripts/create.js",
                "~/Scripts/ViewModel/CreateVM.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/edit").Include(
               "~/Scripts/create.js",
               "~/Scripts/ViewModel/EditVM.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                "~/Scripts/rating.js",
                "~/Scripts/ViewModel/IndexVM.js",
                "~/Scripts/index.js"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-datepicker3.min.css",
                "~/Content/font-awesome/font-awesome.min.css",
                "~/Content/site.css",
                "~/Content/editor.css"
                ));
        }
    }
}
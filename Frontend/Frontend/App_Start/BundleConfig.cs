using System.Web;
using System.Web.Optimization;

namespace Frontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/Options").Include(
                         "~/Scripts/Options/jquery-3.6.0.min.js",
                        "~/Scripts/Options/asyncloader.min.js",
                        "~/Scripts/Options/bootstrap.min.js",
                        "~/Scripts/Options/owl.carousel.min.js",
                        "~/Scripts/Options/jquery.waypoints.min.js",
                        "~/Scripts/Options/jquery.counterup.min.js",
                        "~/Scripts/Options/popper.min.js",
                        "~/Scripts/Options/swiper-bundle.min.js",
                        "~/Scripts/Options/isotope.pkgd.min.js",
                        "~/Scripts/Options/jquery.magnific-popup.min.js",
                        "~/Scripts/Options/slick.min.js",
                        "~/Scripts/Options/streamlab-core.js",
                        "~/Scripts/Options/script.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/AdminJS").Include(
                        "~/Scripts/js/jquery.magnific-popup.min.js",
                        "~/Scripts/js/smooth-scrollbar.js",
                        "~/Scripts/js/select2.min.js",
                        "~/Scripts/js/admin.js"
                                ));
            bundles.Add(new StyleBundle("~/Content/Admin").Include(
                          "~/Content/bootstrap-reboot.min.css",
                            "~/Content/bootstrap-grid.min.css",
                            "~/Content/bootstrap.min.css",
                            "~/Content/CSS/magnific-popup.css",
                            "~/Content/CSS/select2.min.css",
                            "~/Content/CSS/admin.css",
                             "~/Content/CSS/Style.css"
                            ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*", "~/Scripts/icon.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/Scss").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css",
                      "~/Content/styleClient.css",
                      "~/Content/responsive.css",
                      "~/Content/fontawesome.min.css"));

        }
    }
}

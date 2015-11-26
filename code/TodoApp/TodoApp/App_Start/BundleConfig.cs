namespace TodoApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Client/libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Client/libs/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Client/css/bootstrap.css",
                "~/Client/css/bootstrap-social.css",
                "~/Client/css/font-awesome.css",
                 "~/Client/css/todomvc-common.css",
                 "~/Client/css/todomvc-app.css",
                 "~/Client/css/Site.css"));
        }
    }
}

namespace TodoApp
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Client/libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                "~/Client/libs/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-app").Include(
                "~/Client/libs/angular.js",
                "~/Client/libs/angular-route.js",
                "~/Client/libs/angular-resource.js",
                "~/Client/app/app.js",
                "~/Client/app/controllers/todoCtrl.js",
                "~/Client/app/services/todoStorage.js",
                "~/Client/app/directives/todoFocus.js",
                "~/Client/app/directives/todoEscape.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Client/css/bootstrap.css",
                "~/Client/css/bootstrap-social.css",
                "~/Client/css/font-awesome.css",
                 "~/Client/css/todomvc-common.css",
                 "~/Client/css/todomvc-app.css"));
        }
    }
}

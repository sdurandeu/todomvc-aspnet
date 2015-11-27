namespace TodoApp.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

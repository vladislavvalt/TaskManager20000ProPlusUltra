using System.Web.Mvc;

namespace TaskManager20000ProPlusUltra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are happy that you are interested in our awesome service. Stay tuned! :)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We encourage you to contact our technical support operator if you have any questions or email bushkova.nastya@gmail.com if you feel lonely.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.Message = "We are happy that you are interested in our cool commercial service :)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact us if you have any question, you are welcome!";

            return View();
        }
    }
}
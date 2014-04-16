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
            ViewBag.Message = "Not available in your country.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nothing for your country.";

            return View();
        }
    }
}
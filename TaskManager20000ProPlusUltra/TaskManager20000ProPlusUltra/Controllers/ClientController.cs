using System.Web.Mvc;

namespace TaskManager20000ProPlusUltra.Controllers
{
    //TODO uncomment it
    //[Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        public ActionResult Index()
        {
            return View();
        }
    }
}
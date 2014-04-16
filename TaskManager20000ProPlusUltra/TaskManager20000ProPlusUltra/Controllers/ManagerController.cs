using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Controllers
{
    //TODO Uncomment it later
    //[Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {

        private CompanyContext context = new CompanyContext();

        //
        // GET: /Manager/
        public ActionResult Index()
        {
            // it's hardcoded for the first time
            Manager manager = new Manager();
            manager.ManagerId = "Vladislav";
            ViewBag.Manager = manager;
            return View();
        }

        //
        // GET: /Manager/Projects
        public ActionResult Projects()
        {
            Manager manager = new Manager();
            return View(context.Projects.ToList());
        }


        //
        // GET: /Manager/CreateProject
        public ActionResult CreateProject()
        {
            return View();
        }

        //
        // POST: /Manager/CreateProject
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return RedirectToAction("Projects");
            }
            return View(project);
        }

	}
}
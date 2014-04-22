using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskManager20000ProPlusUltra.Service;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Controllers
{
    //TODO Uncomment it later
    //[Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private CompanyContext context = new CompanyContext();
        private UserService UserService;

        public ManagerController()
        {
            UserService = new UserService(context);
        }

        //
        // GET: /Manager/
        public ActionResult Index()
        {
            UserService us = new UserService(context);

            // For the first run
            string id = "2";
            var mq = from m in this.context.Managers where (m.ManagerId == id) select m;
            Manager manager = mq.First();

            manager.User = UserService.FindUserById(id);
            ViewBag.Manager = manager;
            return View();
        }

        //
        // GET: /Manager/Projects
        public ActionResult Projects()
        {
            string id = "2";
            var mq = from m in this.context.Managers where (m.ManagerId == id) select m;
            Manager manager = mq.First();

            manager.User = UserService.FindUserById(id);
            ViewBag.Manager = manager;
            var projects = context.Projects.ToList();
            projects.ForEach(c => c.Client.User = UserService.FindUserById(c.ClientId));
            return View(context.Projects.ToList());
        }

        //
        // GET: /Manager/CurrentProjects
        public ActionResult CurrentProjects()
        {
            string id = "2";
            var mq = from m in this.context.Managers where (m.ManagerId == id) select m;
            Manager manager = mq.First();
            manager.User = UserService.FindUserById(id);
            ViewBag.Manager = manager;
            var currProj = (from cp in this.context.Projects where cp.ManagerId == id && DateTime.Compare(cp.Deadline, cp.EndDate) <= 0 select cp).ToList();
            currProj.ForEach(c => c.Client.User = UserService.FindUserById(c.ClientId));
            return View(currProj);
        }

        //
        // GET: /Manager/CompletedProjects
        public ActionResult CompletedProjects()
        {
            string id = "2";
            var mq = from m in this.context.Managers where (m.ManagerId == id) select m;
            Manager manager = mq.First();
            manager.User = UserService.FindUserById(id);
            ViewBag.Manager = manager;
            var currProj = (from cp in this.context.Projects where cp.ManagerId == id && DateTime.Compare(cp.Deadline, cp.EndDate) > 0 select cp).ToList();
            currProj.ForEach(c => c.Client.User = UserService.FindUserById(c.ClientId));
            return View(currProj);
        }

        //
        // GET: /Manager/ProjectTasks
        public ActionResult ProjectTasks([Bind(Include = "projectId")] string projectId)
        {
            var project = context.Projects.Find(projectId);
            ViewBag.ProjectId = projectId;
            return View(project.Tasks);
        }

        // GET: /Task/Create
        public ActionResult CreateTask([Bind(Include = "projectId")] string projectId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var employees = (from e in context.Employees select e).ToList();
            employees.ForEach(e => e.User = UserService.FindUserById(e.EmployeeId));

            employees.ForEach(m => items.Add(new SelectListItem { Text = m.User.FirstName + " " + m.User.LastName, Value = m.EmployeeId }));
            items.First().Selected = true;

            ViewBag.EmployeeId = items;
            ViewBag.ProjectId = projectId;

            return View();
        }

        // POST: /Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask([Bind(Include = "TaskId,Name,Description,Status,Deadline,StartDate,EndDate,EmployeeId")] Task task,
            [Bind(Include = "projectId")] string projectId)
        {
            if (ModelState.IsValid)
            {
                var project = context.Projects.Find(projectId);
                project.Tasks.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        //
        // GET: /Manager/Teams
        public ActionResult Teams()
        {
            string id = "2";
            var tq = from team in this.context.Teams where team.ManagerId == id select team;
            var mq = from m in this.context.Managers where (m.ManagerId == id) select m;
            Manager manager = mq.First();

            manager.User = UserService.FindUserById(id);
            ViewBag.Manager = manager;
            return View(tq.ToList());
        }

        // create team
        // GET: /Manager/CreateTeam
        public ActionResult CreateTeam()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var managers = (from m in context.Managers select m).ToList();
            managers.ForEach(m => m.User = UserService.FindUserById(m.ManagerId));

            managers.ForEach(m => items.Add(new SelectListItem { Text = m.User.FirstName + " " + m.User.LastName, Value = m.ManagerId }));
            items.First().Selected = true;

            var employee = (from e in context.Employees select e).ToList();
            employee.ForEach(e => e.User = UserService.FindUserById(e.EmployeeId));
            MultiSelectList multieEmployeeList = new MultiSelectList(employee);//, "EmployeeId", "Employee.User.FirstName", null);

            ViewBag.ManagerId = items;
            ViewBag.Employees = employee;
            //ViewBag.Countrieslist = multieEmployeeList;//GetCountries(null);

            return View();
        }

        // POST: /Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam([Bind(Include = "TeamId,ManagerId")] Team team, [Bind(Include = "employeeIdList")] List<string> employeeIdList)
        {
            if (ModelState.IsValid)
            {
                team.Employees = new List<Employee>();
                employeeIdList.ForEach(e => team.Employees.Add(context.Employees.Find(e)));
                context.Teams.Add(team);
                context.SaveChanges();
                return RedirectToAction("Teams");
            }

            return View(team);
        }

        // delete team

        // GET: /Team/Delete/5
        public ActionResult DeleteTeam(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = context.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: /Team/Delete/5
        [HttpPost, ActionName("DeleteTeam")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Team team = context.Teams.Find(id);
            try
            {
                team.Employees = null;
                context.Entry(team).State = EntityState.Modified;
                context.SaveChanges();
                context.Teams.Remove(team);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Teams");
            }
        }

        // delete team

        //
        // GET: /Manager/CreateProject
        public ActionResult CreateProject()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var clients = (from e in context.Clients select e).ToList();
            clients.ForEach(e => e.User = UserService.FindUserById(e.ClientId));

            clients.ForEach(m => items.Add(new SelectListItem { Text = m.User.FirstName + " " + m.User.LastName, Value = m.ClientId }));
            items.First().Selected = true;

            ViewBag.ClientId = items;

            items = new List<SelectListItem>();

            var managers = (from m in context.Managers select m).ToList();
            managers.ForEach(m => m.User = UserService.FindUserById(m.ManagerId));

            managers.ForEach(m => items.Add(new SelectListItem { Text = m.User.FirstName + " " + m.User.LastName, Value = m.ManagerId }));
            items.First().Selected = true;

            ViewBag.ManagerId = items;

            items = new List<SelectListItem>();

            var teams = (from m in context.Teams select m).ToList();

            teams.ForEach(m => items.Add(new SelectListItem { Text = m.TeamId, Value = m.TeamId }));
            items.First().Selected = true;

            ViewBag.TeamId = items;

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

        public ActionResult CloseProject([Bind(Include = "projectId")]string projectId)
        {
            if (ModelState.IsValid)
            {
                var project = context.Projects.Find(projectId);
                project.Status = "RESOLVED";
                project.EndDate = DateTime.Now;
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Projects");
        }

        public ActionResult CloseProjectTask([Bind(Include = "taskId")] string taskId)
        {
            var projectId = "1";
            if (ModelState.IsValid)
            {
                var task = context.Tasks.Find(taskId);
                task.Status = "Closed";
                task.EndDate = DateTime.Now;
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("ProjectTasks?projectId=" + projectId);
        }
    }
}
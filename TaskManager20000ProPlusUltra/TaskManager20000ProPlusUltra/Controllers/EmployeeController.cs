using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskManager20000ProPlusUltra.Models;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            ViewBag.User = LoggedInUser();
            ViewBag.Employee = GetEmployee(ViewBag.User);
            return View();
        }

        public ActionResult CurrentTasks()
        {
            return Tasks(false);
        }

        public ActionResult CompletedTasks()
        {
            return Tasks(true);
        }

        public ActionResult Completed(string id)
        {
            var user = LoggedInUser();
            using (var context = new CompanyContext())
            {
                var tasks = from task in context.Tasks
                            where task.EmployeeId == user.Id && task.TaskId == id
                            select task;
                foreach (var t in tasks)
                {
                    t.EndDate = DateTime.Now;
                    t.Status = "COMPLETED";
                }
                context.SaveChanges();
            }
            return View();
        }

        private ActionResult Tasks(bool completed)
        {
            var employee = LoggedInUser();
            IEnumerable<Task> tasks;

            using (var context = new CompanyContext())
            {
                tasks = from task in context.Tasks
                        where task.EmployeeId == employee.Id && (completed ? task.Status == "COMPLETED" : task.Status == "OPENED")
                        orderby task.Deadline
                        select task;
                tasks = tasks.ToList();
            }

            return View(tasks);
        }

        private ApplicationUser LoggedInUser()
        {
            var userId = User.Identity.GetUserId();
            using (var context = new CompanyContext())
            {
                var users = from u in context.Users
                            where u.Id == userId
                            select u;

                foreach (var u in users)
                {
                    return u;
                }
            }

            return null;
        }

        private Employee GetEmployee(ApplicationUser user)
        {
            using (var context = new CompanyContext())
            {
                var employees = from employee in context.Employees
                                where employee.EmployeeId == user.Id
                                select employee;

                foreach (var e in employees)
                {
                    return e;
                }
            }

            return null;
        }
    }
}
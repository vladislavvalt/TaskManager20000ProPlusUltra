using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
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

        public ActionResult Tasks()
        {
            var employee = LoggedInUser();
            IEnumerable<Task> tasks;

            using (var context = new CompanyContext())
            {
                tasks = from task in context.Tasks
                    where task.EmployeeId == employee.Id
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
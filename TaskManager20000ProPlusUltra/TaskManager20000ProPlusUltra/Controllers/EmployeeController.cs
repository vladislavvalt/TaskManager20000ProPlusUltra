using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
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
            ViewBag.Employee = LoggedInEmployee();
            return View();
        }

        public ActionResult Tasks()
        {
            var employee = LoggedInEmployee();
            IEnumerable<Task> tasks;
            using (var context = new CompanyContext())
            {
                tasks = from task in context.Tasks
                    where task.EmployeeId == employee.EmployeeId
                    select task;
                tasks = tasks.ToList();
            }
            return View(tasks);
        }

        private Employee LoggedInEmployee()
        {
            Employee employee = new Employee();
            employee.EmployeeId = "4";
            return employee;
        }
	}
}
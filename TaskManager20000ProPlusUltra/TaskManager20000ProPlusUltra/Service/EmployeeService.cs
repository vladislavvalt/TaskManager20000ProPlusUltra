using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class EmployeeService : Service<Employee>
    {
        List<Task> getTasks(String employeeId)
        {
            return GetByID(employeeId).Tasks;
        }

        List<Task> getTasks(Employee employee)
        {
            return employee.Tasks;
        }
    }
}
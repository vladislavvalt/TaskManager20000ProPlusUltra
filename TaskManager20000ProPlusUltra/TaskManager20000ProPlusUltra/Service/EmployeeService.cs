using System;
using System.Collections.Generic;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class EmployeeService : Service<Employee>
    {
        public EmployeeService(CompanyContext context)
            : base(context)
        {
        }

        private List<Task> getTasks(String employeeId)
        {
            return GetByID(employeeId).Tasks;
        }

        private List<Task> getTasks(Employee employee)
        {
            return employee.Tasks;
        }
    }
}
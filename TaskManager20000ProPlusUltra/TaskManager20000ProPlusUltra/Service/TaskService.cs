using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class TaskService : Service<Task>
    {
        public TaskService(CompanyContext context) : base(context) { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager20000ProPlusUltra.Models;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class UserService : Service<ApplicationUser>
    {
        public UserService(CompanyContext context): base(context) { }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class ProjectService : Service<Project>
    {
        public ProjectService(CompanyContext context):base(context){}
    }
}
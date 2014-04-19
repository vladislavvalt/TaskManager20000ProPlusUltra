﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager20000ProPlusUltra.Models;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using TaskManager20000ProPlusUltra.Models;

namespace TaskManager20000ProPlusUltra.Service
{
    public class UserService : Service<ApplicationUser>
    {
        public UserService(CompanyContext context): base(context) {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new CompanyContext()));
        }

        internal UserManager<ApplicationUser> UserManager { get; private set; }

        public ApplicationUser FindUserById(string id){
            return UserManager.FindById(id);
        }
    }
}
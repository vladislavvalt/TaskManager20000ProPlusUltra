﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager20000ProPlusUltra.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        public ActionResult Index()
        {
            return View();
        }
	}
}
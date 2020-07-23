using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ShareController : Controller
    {            [HttpGet]
        public ActionResult NoFound()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View();
            }

        }
    }
}

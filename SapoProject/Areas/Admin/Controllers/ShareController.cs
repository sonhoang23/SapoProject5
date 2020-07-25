using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Repository;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ShareController : Controller
    {
        private readonly SapoProjectDbContext _context;
        ShareRepository shareRepository;
        public ShareController(SapoProjectDbContext context)
        {
            this._context = context;
            this.shareRepository = new ShareRepository(_context);
        }
        [HttpGet]
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

     /*   public IActionResult PartialView_Header()
        {
            ViewData["User"] = shareRepository.GetUserById((int)HttpContext.Session.GetInt32("Id"));
            ViewData["userName"] = shareRepository.GetUserById((int)HttpContext.Session.GetInt32("Id")).UserName;
            return View();

        }

        public IActionResult OnGetPartial() =>
    new PartialViewResult
    {
        ViewName = "PartialView_Header",
        ViewData = ViewData,
    };
                          */
    }

}

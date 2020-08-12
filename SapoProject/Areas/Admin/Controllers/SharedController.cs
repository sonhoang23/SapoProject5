using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Repository.Interface;

namespace SapoProject.Areas.Admin.Controllers
{
    public class SharedController : Controller
    {
        private readonly ISharedRepository _shareRepository;
        public SharedController(ISharedRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }
        [HttpGet]
        public IActionResult GetProductByCategory(String id)
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SapoProject.Areas.Admin.Models;
using SapoProject.Areas.Admin.Models;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Repository.Repo;

namespace SapoProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly SapoProjectDbContext _context;
        ProductRepository userRepository;
        public HomeController(SapoProjectDbContext context)
        {
            this._context = context;
            this.userRepository = new ProductRepository(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

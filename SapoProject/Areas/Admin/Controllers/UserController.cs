using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Controllers.Interface;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Repo;

namespace SapoProject.Areas.Admin.Controllers
{
    public class UserController : Controller, IUserController
    {
        private readonly SapoProjectDbContext _context;
        UserRepository userRepository;
        public UserController(SapoProjectDbContext context)
        {
            this._context = context;
            this.userRepository = new UserRepository(_context);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(UserRegister user)
        {
            userRepository.CreateUser(user);
        }
    }
}
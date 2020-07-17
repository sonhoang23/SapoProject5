using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Controllers.Interface;
using SapoProject.Models.Data;
using SapoProject.Models.Entities;
using SapoProject.Repository.Repo;

namespace SapoProject.Controllers
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
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult Register()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
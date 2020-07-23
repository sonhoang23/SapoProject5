using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (HttpContext.Session.GetString("username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {

            if (ModelState.IsValid)
            {
                if (userRepository.LoginUser(user) == 1)
                {
                    HttpContext.Session.SetString("username", user.userAccount);
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                if (userRepository.LoginUser(user) == 0)
                {
                    return RedirectToAction(actionName: "Login", controllerName: "User");
                }

            }
            else
            {
                return View(user);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction(actionName: "Login", controllerName: "User");
         
        }
        //return View();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister user)
        {
            userRepository.CreateUser(user);
            return RedirectToAction(actionName: "Login", controllerName: "User");
        }
    }
}
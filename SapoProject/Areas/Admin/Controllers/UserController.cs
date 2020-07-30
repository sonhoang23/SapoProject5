﻿using System;
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
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Admin.Repository.Repo;

namespace SapoProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult Login()
        {
           
                return View();
         
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {

            if (ModelState.IsValid)
            {
                if (_userRepository.LoginUser(user) == 1)
                {
                    HttpContext.Session.SetString("username", user.userAccount);
                    HttpContext.Session.SetInt32("id", user.Id);
                    return RedirectToAction(actionName: "GetListProductWithDetail", controllerName: "Product");
                }
                if (_userRepository.LoginUser(user) == 0)
                {
                    ViewBag.Title = "Login To Sapo";
                    return RedirectToAction(actionName: "Login", controllerName: "User");
                }
            }
            else
            {
                return View(user);
            }
            return RedirectToAction(actionName: "Login", controllerName: "User");
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
            if (_userRepository.CreateUser(user) == 1)
            {   //chấp nhận register
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            if (_userRepository.CreateUser(user) == 2)
            {   //trùng acc
                return RedirectToAction(actionName: "Register", controllerName: "User");
            }
            if (_userRepository.CreateUser(user) == 3)
            {   //sai mk xác nhận
                return RedirectToAction(actionName: "Register", controllerName: "User");
            }
            return RedirectToAction(actionName: "Register", controllerName: "User");
        }
        [HttpGet]
        public ActionResult Index()
        {
            
                return View();
          
        }
    }
}
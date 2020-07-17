using Microsoft.AspNetCore.Mvc;
using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Controllers.Interface
{
    interface IUserController
    {
        //REGISTER
        [HttpGet]
        public ActionResult Register();
        [HttpPost]
        public ActionResult Register(User user);
        //LOGIN
        [HttpGet]
        public ActionResult Login();
        [HttpPost]
        public ActionResult Login(User user);
    }
}

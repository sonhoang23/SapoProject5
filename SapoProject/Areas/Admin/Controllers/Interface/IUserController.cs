using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;

namespace SapoProject.Areas.Admin.Controllers.Interface
{
    interface IUserController
    {
        //REGISTER
        [HttpGet]
        public ActionResult Register();
        [HttpPost]
        public void/*ActionResult*/ Register(UserRegister user);
        //LOGIN
        [HttpGet]
        public ActionResult Login();
        [HttpPost]
        public ActionResult Login(User user);
    }
}

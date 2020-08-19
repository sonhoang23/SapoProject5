using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Models.DTO;

namespace SapoProject.Areas.Admin.Controllers.Interface
{
    interface IUserController
    {
        //REGISTER
        [HttpGet]
        public ActionResult Register();
        [HttpPost]
        public ActionResult Register(UserRegister user);
        //LOGIN
        [HttpGet]
        public ActionResult Login();
        [HttpPost]
        public ActionResult Login(UserLogin user);
    }
}

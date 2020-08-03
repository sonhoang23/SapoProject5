using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using System.Threading.Tasks;

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
            @ViewBag.Title = "Login to Sapo Project";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(UserLogin userLogin)
        {

            if (ModelState.IsValid)
            {
                if (_userRepository.LoginUser(userLogin) == 1)
                {
                    HttpContext.Session.SetString("userAccount", userLogin.userAccount);
                    HttpContext.Session.SetInt32("status", _userRepository.GetUserStatusByUserAccount(userLogin.userAccount));

                    return RedirectToAction(actionName: "GetListProductWithDetail", controllerName: "Product");
                }
                if (_userRepository.LoginUser(userLogin) == 0)
                {
                    ViewBag.Title = "Login To Sapo";
                    return RedirectToAction(actionName: "Login", controllerName: "User");
                }
            }
            else
            {
                return View(userLogin);
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
        public async Task<ActionResult> Register(UserRegister user)
        {
            if (await _userRepository.CreateUser(user) == 1)
            {   //chấp nhận register
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            if (await _userRepository.CreateUser(user) == 2)
            {   //trùng acc
                return RedirectToAction(actionName: "Register", controllerName: "User");
            }
            if (await _userRepository.CreateUser(user) == 3)
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
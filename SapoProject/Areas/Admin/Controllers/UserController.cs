using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Logs;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public UserController(IUserRepository userRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<UserController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
            _userRepository = userRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            @ViewBag.Title = "Đăng Nhập Trang Quản Lý Sapo Project";
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync(UserLogin userLogin, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                /*-------------------test author---------------------*/

                // var userRegister = new IdentityUser { UserName = userLogin.userAccount };
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, 
                // set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(userLogin.userAccount,
                                   userLogin.userPassWord, isPersistent: userLogin.rememberPassWord, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToAction("Index", "Product");
                    }
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new
                //    {
                //        ReturnUrl = returnUrl,
                //        RememberMe = Input.RememberMe
                //    });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    @ViewBag.Title = "Login to Sapo Project";
                    return View(userLogin);
                }

                //hết test author
                /*---------------Phần Login Cũ, Ổn Định------------------*/
                //if (_userRepository.LoginUser(userLogin) == 1)
                //{

                //    HttpContext.Session.SetString("userAccount", userLogin.userAccount);
                //    HttpContext.Session.SetInt32("status", _userRepository.GetUserStatusByUserAccount(userLogin.userAccount));

                //    return RedirectToAction(actionName: "Index", controllerName: "Product");
                //}
                //if (_userRepository.LoginUser(userLogin) == 0)
                //{
                //    ViewBag.Title = "Login To Sapo";
                //    TempData["Message"] = "No Found Account or Input Wrong Password";
                //    return RedirectToAction(actionName: "Login", controllerName: "User");
                //}
            }
            else
            {
                @ViewBag.Title = "Login to Sapo Project";
                return View(userLogin);
            }
        }
        [HttpPost]
        public async Task<ActionResult> LogOutAsync()
        {
            await signInManager.SignOutAsync();


            HttpContext.Session.Remove("username");
            return RedirectToAction(actionName: "Login", controllerName: "User");

        }
        //return View();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                /*-------------------test author---------------------*/
                var userRegister = new IdentityUser { UserName = user.userAccount, Email = user.email, PhoneNumber = user.phoneNumber };
                var result = await userManager.CreateAsync(userRegister, user.userPassWord);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userRegister, isPersistent: false);
                    _logger.LogInformation("Register ok");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    var error = result.Errors.ToList(); //convert to list

                    foreach (var err in error) //iterate through individual error
                    {
                        this.ModelState.AddModelError("Password", err.Description); //add error to modelstate
                        _logger.LogError("Register Error" + err.Description);
                    }
                    //this.ModelState.AddModelError("Password", errList);

                }

                //hết test author
                /*------------Phần register cũ, ổn định----------------*/
                //if (await _userRepository.CreateUser(user) == 1)
                //{   //chấp nhận register

                //    return RedirectToAction(actionName: "Login", controllerName: "User");
                //}
                //if (await _userRepository.CreateUser(user) == 2)
                //{   //trùng acc
                //    return RedirectToAction(actionName: "Register", controllerName: "User");
                //}
                //if (await _userRepository.CreateUser(user) == 3)
                //{   //sai mk xác nhận
                //    return RedirectToAction(actionName: "Register", controllerName: "User");
                //}
                //return RedirectToAction(actionName: "Register", controllerName: "User");
                ///*------------Hết Phần register cũ, ổn định----------------*/
            }
            return View(user);
        }
    }
}
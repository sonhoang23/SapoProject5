using System;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Model.Entities;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Areas.Customer.Models.DTO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SapoProject.Logs;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SapoProject.Areas.Customer.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;
        public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger) /*, UserManager<IdentityUser> userManager,*/
        //    SignInManager<IdentityUser> signInManager)
        {
            //this.userManager = userManager;
            //this.signInManager = signInManager;
        
            _logger = logger;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index(PagingSearch pagingSearch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.searchName = pagingSearch.searchName;
                    ViewBag.categoryName = pagingSearch.categoryName;

                    if (pagingSearch.searchName != null)
                    {
                        return View("Index", _customerRepository.GetListProductWithDetailByMainSearch(pagingSearch.searchName, pagingSearch.pageNumber));
                    }
                    if (pagingSearch.categoryName != null)
                    {
                        // ViewBag.listPagedProduct = _customerRepository.GetListProductWithDetailByCategoryName(pageNumber, name);
                        ViewBag.CategoryName = pagingSearch.categoryName;
                        return View(_customerRepository.GetListProductWithDetailByCategoryName(pagingSearch.pageNumber, pagingSearch.categoryName));
                    }
                    else
                    {
                        ViewBag.CategoryName = null;
                        return View(_customerRepository.GetListProductWithDetail(pagingSearch.pageNumber));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(MyLogEvents.GetItemNotFound, ex, "TestExp({Id})", pagingSearch);
                    return NotFound();
                }

            }
            else
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "BadRequest(Code: {badRequest}, {ModelState})", HttpStatusCode.NotFound, ModelState);
             return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
            }

        }
        [HttpGet]
      
        public ActionResult ProductDetail(int id)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "In Client-Side Product Detail Getting item {Id}", id);
            _customerRepository.UpdateProductViewCount(id);
            Product product = _customerRepository.GetProductByID(id);
            if (product == null)
            {
                return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
            }
            else
            {
                return View(product);
            }

        }
        public JsonResult OnPostProduct()
        {
            return new JsonResult("Hello Response Back");
        }
        /* [HttpGet]
         public ActionResult OnPostProduct(int? pageNumber, String name1)
         {
             ViewBag.listPagedProduct = _customerRepository.GetListProductWithDetailByCategoryName(pageNumber, name1);
             ViewBag.CategoryName = name1;
             return PartialView("_PartialView_MenuProduct");
         }  */
        [HttpGet]
        public ActionResult Login()
        {
            @ViewBag.Title = "Login to Sapo Project";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ClientLogin clientLogin)
        {

            if (ModelState.IsValid)
            {
                if (_customerRepository.LoginUser(clientLogin) == 1)
                {

                    HttpContext.Session.SetString("clientAccount", clientLogin.clientAccount);
                    HttpContext.Session.SetInt32("status", _customerRepository.GetUserStatusByUserAccount(clientLogin.clientAccount));
                    HttpContext.Session.SetInt32("Id", _customerRepository.GetClientIdByClientAccout(clientLogin.clientAccount));

                    return RedirectToAction(actionName: "Index", controllerName: "Customer");
                }
                if (_customerRepository.LoginUser(clientLogin) == 0)
                {
                    ViewBag.Title = "Login To Sapo";
                    TempData["Message"] = "No Found Account or Input Wrong Password";
                    return RedirectToAction(actionName: "Login", controllerName: "Customer");
                }
            }
            else
            {
                @ViewBag.Title = "Login to Sapo Project";
                return View(clientLogin);
            }
            return RedirectToAction(actionName: "Login", controllerName: "Customer");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("clientAccount");
            HttpContext.Session.Remove("status");
            HttpContext.Session.Remove("Id");
            return RedirectToAction(actionName: "Login", controllerName: "Customer");

        }
        //return View();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(ClientRegister clientRegister)
        {
           // var client = new IdentityUser(User = clientRegister.userName);



            if (await _customerRepository.CreateClient(clientRegister) == 1)
            {   //chấp nhận register
                HttpContext.Session.SetString("clientAccount", clientRegister.userAccount);
                HttpContext.Session.SetInt32("status", 1);

                HttpContext.Session.SetString("clientAccount", clientRegister.userAccount);
                HttpContext.Session.SetInt32("status", _customerRepository.GetUserStatusByUserAccount(clientRegister.userAccount));
                HttpContext.Session.SetInt32("Id", _customerRepository.GetClientIdByClientAccout(clientRegister.userAccount));

                return RedirectToAction(actionName: "Index", controllerName: "Customer");
            }
            if (await _customerRepository.CreateClient(clientRegister) == 2)
            {   //trùng acc
                TempData["Message"] = "Have Account Already";
                return View(clientRegister);
            }
            if (await _customerRepository.CreateClient(clientRegister) == 3)
            {   //sai mk xác nhận
                TempData["Message"] = "Please match 2 Password";
                return View(clientRegister);
            }
            if (await _customerRepository.CreateClient(clientRegister) == 4)
            {   //Sdt đã tồn tại
                TempData["Message"] = "Phone Number Exsit";
                return View(clientRegister);
            }
            return View(clientRegister);
        }
        [HttpGet]
        public ActionResult UpdateQuantityByAjax(String productId, String quantity)
        {
            return PartialView("_PartialView_MenuProduct1");
            //return View("");
        }


    }



}
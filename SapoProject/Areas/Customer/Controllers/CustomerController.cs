using System;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Model.Entities;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Areas.Customer.Models.DTO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index(int? pageNumber, String? name)
        {
            if (name == null)
            {
                ViewBag.listPagedProduct = _customerRepository.GetListProductWithDetail(pageNumber);
                ViewBag.CategoryName = null;
            }
            else
            {
                ViewBag.listPagedProduct = _customerRepository.GetListProductWithDetailByCategoryName(pageNumber, name);
                ViewBag.CategoryName = name;
            }
            // return View(_customerRepository.GetListProductWithDetail(pageNumber));
            return View();
        }
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            Product product = _customerRepository.GetProductByID(id);
            return View(product);
        }
        /*   public JsonResult OnPostProduct()
            {
                return new JsonResult("Hello Response Back");
            }    */
        [HttpGet]
        public ActionResult OnPostProduct(int? pageNumber, String name1)
        {
            ViewBag.listPagedProduct = _customerRepository.GetListProductWithDetailByCategoryName(pageNumber, name1);
            ViewBag.CategoryName = name1;
            return PartialView("_PartialView_MenuProduct");
        }
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
                    return RedirectToAction(actionName: "Login", controllerName: "Customer");
                }
            }
            else
            {
                return View(clientLogin);
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
        public async Task<ActionResult> Register(ClientRegister clientRegister)
        {
            if (await _customerRepository.CreateClient(clientRegister) == 1)
            {   //chấp nhận register
                HttpContext.Session.SetString("clientAccount", clientRegister.userAccount);
                HttpContext.Session.SetInt32("status", 1);

                return RedirectToAction(actionName: "Index", controllerName: "Customer");
            }
            if (await _customerRepository.CreateClient(clientRegister) == 2)
            {   //trùng acc
                return RedirectToAction(actionName: "Register", controllerName: "Customer");
            }
            if (await _customerRepository.CreateClient(clientRegister) == 3)
            {   //sai mk xác nhận
                return RedirectToAction(actionName: "Register", controllerName: "Customer");
            }
            return RedirectToAction(actionName: "Register", controllerName: "Customer");
        }

    }

}
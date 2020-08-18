using System;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Model.Entities;
using SapoProject.Areas.Customer.Repository.Interface;

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
      
    }

}
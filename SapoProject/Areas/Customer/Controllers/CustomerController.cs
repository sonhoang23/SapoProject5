using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
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
    }

}
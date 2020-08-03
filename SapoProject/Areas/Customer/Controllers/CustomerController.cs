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
        private readonly ICustomerRepository _Repository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _Repository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index(int? pageNumber)
        {
            ViewBag.listPagedProduct = _Repository.GetListProductWithDetail(pageNumber);
            return View(_Repository.GetListProductWithDetail(pageNumber));
        }
    }

}
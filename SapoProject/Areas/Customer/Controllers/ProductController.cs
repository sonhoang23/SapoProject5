using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Models.DTO;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Model.Entities;

namespace SapoProject.Areas.Customer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCustomerRepository _productRepository;
        public ProductController(IProductCustomerRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public void AddToOrder(ProductAddToOrder product)
        {
           
        }
    }
}

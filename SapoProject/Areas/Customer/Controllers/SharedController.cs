using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;

namespace SapoProject.Areas.Customer.Controllers
{
    public class SharedController : Controller
    {
        private readonly ISharedCustomerRepository _Repository;
        public SharedController(ISharedCustomerRepository customerRepository)
        {
            _Repository = customerRepository;
        }
    }

}
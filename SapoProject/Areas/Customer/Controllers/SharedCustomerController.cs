using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Customer.Repository.Interface;

namespace SapoProject.Areas.Customer.Controllers
{

    public class SharedCustomerController : Controller
    {
        private readonly ISharedCustomerRepository _Repository;
        public SharedCustomerController(ISharedCustomerRepository customerRepository)
        {
            _Repository = customerRepository;
        }
    }

}
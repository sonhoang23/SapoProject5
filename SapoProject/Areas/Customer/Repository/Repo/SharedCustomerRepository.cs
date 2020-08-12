using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Customer.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SapoProject.Areas.Customer.Repository.Repo
{
    public class SharedCustomerRepository : ISharedCustomerRepository
    {
        private readonly SapoProjectDbContext _context;

        public SharedCustomerRepository(SapoProjectDbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {

        }
        public List<Category> ListAllChildCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 2).ToList();
        }
        public List<Category> ListAllParentCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 1).ToList();
        }

        public void Save()
        {
           
        }
    }
}
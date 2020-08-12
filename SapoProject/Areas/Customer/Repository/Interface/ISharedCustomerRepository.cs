using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Repository.Interface
{
    public interface ISharedCustomerRepository : IDisposable
    {
        List<Category> ListAllChildCategory();
        List<Category> ListAllParentCategory();
        void Save();
        void Dispose();
    }
}

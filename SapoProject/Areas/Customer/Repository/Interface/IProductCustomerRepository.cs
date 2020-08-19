using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Repository.Interface
{
    public interface IProductCustomerRepository : IDisposable
    {
        void Save();
        void Dispose();
    }
}

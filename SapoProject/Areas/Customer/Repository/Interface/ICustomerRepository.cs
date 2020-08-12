using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SapoProject.Areas.Customer.Models.Entities;
using SapoProject.Areas.Admin.Models.Entities;
using X.PagedList;

namespace SapoProject.Areas.Customer.Repository.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        IPagedList<Product> GetListProductWithDetail(int? pageNumber);
        IPagedList<Product> GetListProductWithDetailByCategoryName(int? page, String categoryName);
        Product GetProductByID(int productID);
        String GetCategoryNameById(int Id);
        void Save();
        void Dispose();

    }
}

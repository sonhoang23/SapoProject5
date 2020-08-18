using System;
using SapoProject.Model.Entities;
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

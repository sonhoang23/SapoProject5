using System;
using System.Threading.Tasks;
using SapoProject.Areas.Customer.Models.DTO;
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
        int LoginUser(ClientLogin userLogin);
        Task<int> CreateClient(ClientRegister User);
        int GetUserStatusByUserAccount(string UserAccount);
        int GetClientIdByClientAccout(string clientAccount);
        void Save();
        void Dispose();

    }
}

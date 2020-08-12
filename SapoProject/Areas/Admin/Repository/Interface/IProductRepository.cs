using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IProductRepository : IDisposable
    {
        Task<IEnumerable<Product>> GetListProductWithDetail();
        IEnumerable<Product> GetListProductWithoutDetail();
        Product GetProductByID(int productID);
        ProductEdit GetProductEditByID(int productID);
        Task CreateProduct(ProductCreate productCreate);
        Task DeleteProduct(int product);
        Task UpdateProduct(ProductEdit productEdit);
        List<String> GetCategoryName();
        String GetCategoryNameById(int Id);
        List<String> GetCategoryNameOrderByProductCategory(int Id);
        void Save();
        void Dispose();

    }
}

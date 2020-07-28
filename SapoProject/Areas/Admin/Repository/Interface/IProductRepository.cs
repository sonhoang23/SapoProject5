using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IProductRepository:IDisposable
    {
        IEnumerable<Product> GetListProductWithDetail();
        IEnumerable<Product> GetListProductWithoutDetail();
        Product GetProductByID(int productID);
        void CreateProduct(ProductCreate productCreate);
        void DeleteProduct(int product);
        void UpdateProduct(ProductEdit productID);
        void Save();
    }
}

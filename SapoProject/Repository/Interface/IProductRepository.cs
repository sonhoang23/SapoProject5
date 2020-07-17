using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Repository.Interface
{
    public interface IProductRepository:IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productID);
        void CreateProduct(Product product);
        void DeleteProduct(int product);
        Product Edit(int productID);
        void UpdateProduct(Product productID);
        void Save();
    }
}

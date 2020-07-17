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
        void InsertProduct(Product product);
        void DeleteProduct(int product);
        void UpdateProduct(Product productID);
        void Save();
    }
}

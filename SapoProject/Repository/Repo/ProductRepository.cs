using Microsoft.EntityFrameworkCore;
using SapoProject.Models.Data;
using SapoProject.Models.Entities;
using SapoProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Repository.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly SapoProjectDbContext _context;
        public ProductRepository(SapoProjectDbContext context)
        {
            this._context = context;
        }
        //POST: create
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Product.ToList();
        }
        public Product GetProductByID(int productID)
        {
            throw new NotImplementedException();
        }
        public async void UpdateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
          
        }
        public void DeleteProduct(int product)
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Product Edit(int productID)
        {
            if (productID == null)
            {
                throw new NotImplementedException();
            }

            var product =  _context.Product.Find(productID);
            if (product == null)
            {
                throw new NotImplementedException();
            }
            return product;
        }
    }
}

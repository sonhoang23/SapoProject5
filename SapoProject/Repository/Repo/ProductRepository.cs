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
            _context.Add(product);
            _context.SaveChangesAsync();
        }
        public IEnumerable<Product> GetListProductWithDetail()
        {
            return _context.Product.ToList();
        }
        public IEnumerable<Product> GetListProductWithoutDetail()
        {
            return _context.Product.ToList();
        }
        public Product GetProductByID(int productID)
        {
            return _context.Product.Find(productID);
        }
        public  void UpdateProduct(Product product)
        {
             _context.Update(product);
             _context.SaveChangesAsync();
          
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

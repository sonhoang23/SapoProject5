using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Repo
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
            product.CreatedDate = DateTime.Now;
            product.FixedDate = DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();
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
        public void UpdateProduct(Product product)
        {
            product.FixedDate = DateTime.Now;
            _context.Update(product);
            _context.SaveChanges();

        }
        public void DeleteProduct(int productID)
        {
            if (productID == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                Product productToDelete = new Product() { Id = productID };
                _context.Entry(productToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
               // _context.Product.Remove(GetProductByID(productID));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        
      
    }
}

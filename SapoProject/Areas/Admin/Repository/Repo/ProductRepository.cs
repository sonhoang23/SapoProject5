using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Administration;
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
        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        static private string GetConnectionString()
        {
            return "Server=.;Database=SapoProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }



        //POST: create
        public void CreateProduct(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.FixedDate = DateTime.Now;
            product.Status = 1;
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
        public IEnumerable<Product> GetListProductWithoutDetail(int page)
        {
            String sql = "SELECT * FROM Product LIMIT @start, @limit";
            List<Product> pageProduct = new List<Product>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@start", (page-1)*10);
                command.Parameters.AddWithValue("@limit", page);
                command.ExecuteReader();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductName = reader.GetString(0);
                        product.Price = reader.GetString(1);
                        product.OriginalPrice = reader.GetString(2);
                        product.ShortDescription = reader.GetString(3);
                        product.EntireDescription = reader.GetString(4);
                        product.ViewCount = reader.GetInt32(5);
                        product.CreatedDate = reader.GetDateTime(6);
                        product.FixedDate = reader.GetDateTime(7);
                        pageProduct.Add(product);

                    }
                }
            
            }
            return pageProduct;
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
            Product product = GetProductByID(productID);
            product.Status = 0;
            _context.Update(product);
            _context.SaveChanges();


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

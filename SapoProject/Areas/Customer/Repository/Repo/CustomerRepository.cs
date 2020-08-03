using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Customer.Models.Entities;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
namespace SapoProject.Areas.Customer.Repository.Repo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SapoProjectDbContext _context;

        public CustomerRepository(SapoProjectDbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {

        }
        /*   public List<ProductClient> GetListProductWithDetail()
           {
               String sql = "SELECT * FROM Product";
               List<ProductClient> productClients = new List<ProductClient>();
               using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
               {
                   connection.Open();
                   SqlCommand command = new SqlCommand(sql, connection);
                   using (SqlDataReader reader = command.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           ProductClient product = new ProductClient();
                           product.Id = reader.GetInt32(1);
                           product.ProductName = reader.GetString(1).ToString();
                           product.Price = reader.GetString(2).ToString();
                           product.OriginalPrice = reader.GetString(3).ToString();
                           product.ShortDescription = reader.GetString(4).ToString();
                           product.EntireDescription = reader.GetString(5).ToString();
                           product.ViewCount = reader.GetInt32(6);
                           product.CreatedDate = reader.GetDateTime(7);
                           product.FixedDate = reader.GetDateTime(8);
                           product.FilePath = reader.GetString(10).ToString();
                           productClients.Add(product);
                       }
                   }
               }
               return productClients;

           }*/
        public IPagedList<Product> GetListProductWithDetail(int? page)
        {
             var pageNumber = page ?? 1;
       
            return _context.Product.Where(x => x.Status == 1).ToList().ToPagedList(pageNumber, 10);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

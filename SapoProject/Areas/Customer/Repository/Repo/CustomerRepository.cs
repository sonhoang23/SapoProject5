using Microsoft.Data.SqlClient;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Model.Entities;
using SapoProject.Model;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
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
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();

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
            return _context.Product.Where(x => x.Status == 1).ToList().ToPagedList(pageNumber, 9);
        }
        public String GetCategoryNameById(int Id)
        {
            String sql = "SELECT CategoryName FROM Category where Status != '0' and CategoryId = @CategoryId";
            String CategoryName;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CategoryId", Id);
                connection.Open();
                // command.ExecuteReader();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoryName = reader.GetString(0);
                        return CategoryName;
                    }
                }
            }
            return null;
        }
        public int GetCategoryIdByName(string CategoryName)
        {
            int ParentCategoryId;
            String sql = "SELECT CategoryId FROM Category where CategoryName = @CategoryName";
            //String sql = "SELECT CategoryId FROM Category where CategoryName = 'Electronic Products'";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CategoryName", CategoryName);
                connection.Open();
                // command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ParentCategoryId = reader.GetInt32(0);
                        return ParentCategoryId;
                    }

                }

            }
            return 0;
        }
        public IPagedList<Product> GetListProductWithDetailByCategoryName(int? page, String categoryName)
        {
            var pageNumber = page ?? 1;
            return _context.Product.Where(x => x.Status == 1 && x.CategoryId == GetCategoryIdByName(categoryName)).ToList().ToPagedList(pageNumber, 9);
        }
        public Product GetProductByID(int productID)
        {
            return _context.Product.Find(productID);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

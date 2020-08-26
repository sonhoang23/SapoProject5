using SapoProject.Model.Data;
using SapoProject.Model.Entities;
using SapoProject.Model;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Linq;
using X.PagedList;
using SapoProject.Areas.Customer.Models.DTO;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public int LoginUser(ClientLogin clientLogin)
        {
            User user = new User();

            var userCheck = _context.Client.Where(n => n.ClientAccount == clientLogin.clientAccount && n.ClientPassWord == clientLogin.clientPassWord);
            if (userCheck.Count() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int GetUserStatusByUserAccount(string userAccount)
        {
            int userStatus = (from Client in _context.Client
                              where Client.ClientAccount == userAccount
                              select Client.Status).First();
            return userStatus;
        }
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
        public async Task<int> CreateClient(ClientRegister clientRegister)
        {
            Client client = new Client();
            if (clientRegister.userPassWord == clientRegister.userPassWordAgain && clientRegister.userPassWord != null)
            {
                if (!await _context.Client.AnyAsync(i => i.ClientAccount == clientRegister.userAccount))
                {
                    client.CustomerName = clientRegister.userName;
                    client.PhoneNumber = clientRegister.phoneNumber;
                    client.Address = clientRegister.address + "-" + clientRegister.district + "-" + clientRegister.city + "-" + clientRegister.country;
                    client.Age = clientRegister.age;
                    client.Sex = clientRegister.sex;
                    client.Email = clientRegister.email;
                    client.EmailReset = clientRegister.emailReset;
                    client.ClientAccount = clientRegister.userAccount;
                    client.ClientPassWord = clientRegister.userPassWord;
                    client.Status = 1;
                    await _context.Client.AddAsync(client);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                return 2;
            }
            else
            {
                return 3;
            }
        }
        public int GetClientIdByClientAccout(string clientAccount)
        {
            int Id;
            String sql = "SELECT Id FROM Client where ClientAccount = @clientAccount";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clientAccount", clientAccount);
                connection.Open();
                // command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        return Id;
                    }

                }

            }
            return 0;
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProductViewCount(int id)
        {

            var query =
    from product in _context.Product
    where product.Id == id
    select product;

            foreach (Product product1 in query)
            {
                product1.ViewCount = GetProductViewCountByProductId(id) + 1;
                // Insert any additional changes to column values.
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        }

        private int GetProductViewCountByProductId(int id)
        {
            String sql = "SELECT ViewCount FROM Product where Id = @id";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                // command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int viewCount = reader.GetInt32(0);
                        return viewCount;
                    }

                }
                return 0;

            }
        }

        public IPagedList<Product> MainSearch(string? search, int? page)
        {
            List<Product> products = new List<Product>();
            var pageNumber = page ?? 1;

            if (!String.IsNullOrEmpty(search))
            {
              return _context.Product.Where(s => s.ProductName.Contains(search)).ToList().ToPagedList(pageNumber, 9);
            }

            return null;
        }
    }
}

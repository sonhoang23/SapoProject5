using SapoProject.Model.Data;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapoProject.Model;
using Microsoft.Data.SqlClient;

namespace SapoProject.Areas.Customer.Repository.Repo
{
    public class ProductCustomerRepository: IProductCustomerRepository

    {
        private readonly SapoProjectDbContext _context;

        public ProductCustomerRepository(SapoProjectDbContext context)
        {
            _context = context;

        }
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();

        }
        public int CheckOrderByClientAccount(string clientAccount)
        {
            int ParentCategoryId;
            String sql = "SELECT CategoryId FROM Category where CategoryName = @parentCategoryName";
            //String sql = "SELECT CategoryId FROM Category where CategoryName = 'Electronic Products'";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@parentCategoryName", clientAccount);
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

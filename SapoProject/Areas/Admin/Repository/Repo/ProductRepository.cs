using Microsoft.Data.SqlClient;
using SapoProject.Model.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SapoProject.Model.Entities;
using SapoProject.Model;
namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;

        public ProductRepository(SapoProjectDbContext context, IHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();

        }
        //POST: create
        public async Task CreateProduct(ProductCreate productCreate)
        {
            string uniqueFileName = null;


            String uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\ProductImages");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + productCreate.Photo.FileName;
            String Url = Path.Combine(uploadFolder, uniqueFileName);
            productCreate.Photo.CopyTo(new FileStream(Url, FileMode.Create));
            String filePath = "/ProductImages/" + uniqueFileName;
            Product newProduct = new Product
            {
                ProductName = productCreate.ProductName,
                Price = productCreate.Price,
                OriginalPrice = productCreate.OriginalPrice,
                ShortDescription = productCreate.ShortDescription,
                EntireDescription = productCreate.EntireDescription,
                FilePath = filePath,
                CategoryId = GetCategoryIdByCategoryName(productCreate.CategoryName),
                CreatedDate = DateTime.Now,
                FixedDate = DateTime.Now,
                Status = 1
            };
           
            _context.Add(newProduct);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Product>> GetListProductWithDetail()
        {
            return await _context.Product.Where(x => x.Status == 1).ToListAsync();

        }
        public IEnumerable<Product> GetListProductWithoutDetail()
        {
             return _context.Product.ToList();
         // return  null;
        }
        public List<Product> GetListProductWithoutDetail(int page)
        {
            String sql = "SELECT * FROM Product LIMIT @start, @limit";
            List<Product> pageProduct = new List<Product>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@start", (page - 1) * 10);
                command.Parameters.AddWithValue("@limit", page);
                // command.ExecuteReader();
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
        public ProductEdit GetProductEditByID(int productID)
        {
            Product product = GetProductByID(productID);
            ProductEdit productEdit = new ProductEdit
            {
                ProductName = product.ProductName,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                ShortDescription = product.ShortDescription,
                EntireDescription = product.EntireDescription,
                CategoryName = GetCategoryNameById(product.CategoryId),
                CreatedDate = product.CreatedDate,
                FilePath = product.FilePath,
                FixedDate = product.FixedDate,
                Id = product.Id,
                Status = product.Status,
                ViewCount = product.ViewCount,

            };
            return productEdit;
        }

        public Product GetProductByID(int productID)
        {
            return _context.Product.Find(productID);
        }
        public async Task UpdateProduct(ProductEdit productEdit)
        {
            if (productEdit.Photo != null)
            {
                String uniqueFileName = null;
                String uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\ProductImages");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + productEdit.Photo.FileName;
                String Url = Path.Combine(uploadFolder, uniqueFileName);
                productEdit.Photo.CopyTo(new FileStream(Url, FileMode.Create));
                String filePath = "/ProductImages/" + uniqueFileName;

                Product product = new Product
                {
                    Id = productEdit.Id,
                    ProductName = productEdit.ProductName,
                    Price = productEdit.Price,
                    OriginalPrice = productEdit.OriginalPrice,
                    ShortDescription = productEdit.ShortDescription,
                    EntireDescription = productEdit.EntireDescription,
                    CategoryId = GetCategoryIdByCategoryName(productEdit.CategoryNameEdit),
                    FilePath = filePath,
                    CreatedDate = productEdit.CreatedDate,
                    FixedDate = DateTime.Now,
                    Status = 1,
                    ViewCount = productEdit.ViewCount

                };
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                Product product = new Product
                {
                    Id = productEdit.Id,
                    ProductName = productEdit.ProductName,
                    Price = productEdit.Price,
                    OriginalPrice = productEdit.OriginalPrice,
                    ShortDescription = productEdit.ShortDescription,
                    EntireDescription = productEdit.EntireDescription,
                    CategoryId = GetCategoryIdByCategoryName(productEdit.CategoryNameEdit),
                    FilePath = productEdit.FilePath,
                    CreatedDate = DateTime.Now,
                    FixedDate = DateTime.Now,
                    Status = 1,
                    ViewCount = productEdit.ViewCount

                };
                _context.Update(product);
                await _context.SaveChangesAsync();
            }


        }
        public async Task DeleteProduct(int productID)
        {
            Product product = GetProductByID(productID);
            product.Status = 0;
            _context.Update(product);
            await _context.SaveChangesAsync();

        }
        public List<String> GetCategoryName()
        {
            String sql = "SELECT CategoryName FROM Category where Status = '1'";
            List<String> ParentCategoryName = new List<String>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                // command.ExecuteReader();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ParentCategoryName.Add(reader.GetString(0));
                    }
                }
            }
            return ParentCategoryName;
        }
        public int GetCategoryIdByCategoryName(string CategoryName)
        {
            int CategoryId;
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
                        CategoryId = reader.GetInt32(0);
                        return CategoryId;
                    }

                }

            }
            return 0;
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
        public List<String> GetCategoryNameOrderByProductCategory(int Id)
        {

            List<String> GetCategoryNameOrderByProductCategory = new List<String>();
            GetCategoryNameOrderByProductCategory.Add(GetCategoryNameById(GetCategoryIdByProductId(Id)));
            GetCategoryNameOrderByProductCategory.AddRange(GetCategoryName());
            return GetCategoryNameOrderByProductCategory;
        }
        public int GetCategoryIdByProductId(int Id)
        {
            String sql = "SELECT CategoryId FROM Product where Status != '0' and Id = @CategoryId";

            int CategoryId;

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
                        CategoryId = reader.GetInt32(0);
                        return CategoryId;
                    }
                }
            }
            return 0;
        }
        public void Dispose()
        {

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Administration;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductRepository(SapoProjectDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._hostingEnvironment = hostingEnvironment;
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
        public void CreateProduct(ProductCreate productCreate)
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
                CreatedDate = DateTime.Now,
                FixedDate = DateTime.Now,
                Status = 1
            };

            _context.Add(newProduct);
            _context.SaveChanges();
        }
        public IEnumerable<Product> GetListProductWithDetail()
        {
            return _context.Product.Where(x=>x.Status==1).ToList();
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
                command.Parameters.AddWithValue("@start", (page - 1) * 10);
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
        public void UpdateProduct(ProductEdit productEdit)
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
                    FilePath = filePath,
                    CreatedDate = productEdit.CreatedDate,
                    FixedDate = DateTime.Now,
                    Status = 1,
                    ViewCount = productEdit.ViewCount

                }; 
                _context.Update(product);
                _context.SaveChanges();
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
                    FilePath = productEdit.FilePath,
                    CreatedDate = DateTime.Now,
                    FixedDate = DateTime.Now,
                    Status = 1,
                    ViewCount = productEdit.ViewCount

                }; 
                _context.Update(product);
                _context.SaveChanges();
            }



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

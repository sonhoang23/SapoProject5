using Microsoft.Data.SqlClient;
using SapoProject.Model.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Hosting;
using SapoProject.Model.Entities;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;

        public CategoryRepository(SapoProjectDbContext context, IHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        static private string GetConnectionString()
        {
            return "Server=.;Database=SapoProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        //POST: create
        public async Task CreateCategory(CategoryCreate categoryCreate)
        {
            string uniqueFileName = null;

            String uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\CategoryImages");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + categoryCreate.Photo.FileName;
            String Url = Path.Combine(uploadFolder, uniqueFileName);
            categoryCreate.Photo.CopyTo(new FileStream(Url, FileMode.Create));
            String filePath = "/CategoryImages/" + uniqueFileName;
            Category newCategory = new Category
            {
                CategoryName = categoryCreate.CategoryName,
                imageURL = filePath,
                IsShowOnHome = 1,
                ParentId =  GetParentCategoryId(categoryCreate.ParentCategoryName),
                ShortDescription = categoryCreate.ShortDescription,
                SortOrder = 1,
                Status = 1
            };

            await _context.AddAsync(newCategory);
            await _context.SaveChangesAsync();
        }
        public int GetParentCategoryId(string parentCategoryName)
        {
            int ParentCategoryId;
            String sql = "SELECT CategoryId FROM Category where CategoryName = @parentCategoryName";
            //String sql = "SELECT CategoryId FROM Category where CategoryName = 'Electronic Products'";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@parentCategoryName", parentCategoryName);
                connection.Open();
                // command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ParentCategoryId = reader.GetInt32(0);
                        return  ParentCategoryId;
                    }

                }

            }
            return 0;
        }
        public String GetCategoryNameById(int Id)
        {
            String sql = "SELECT CategoryName FROM Category where Status = '2' and CategoryId = @CategoryId";
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

        public int GetParentCategoryIdByChildCategoryId(int Id)
        {
            String sql = "SELECT ParentId FROM Category where Status != '0' and CategoryId = @CategoryId";
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
        public List<String> GetParentCategoryNameOrderByChildCatgory(int Id)
        {

            List<String> GetParentCategoryNameOrderByChildCatgory = new List<String>();
            GetParentCategoryNameOrderByChildCatgory.Add(GetCategoryNameById(GetParentCategoryIdByChildCategoryId(Id)));
            GetParentCategoryNameOrderByChildCatgory.AddRange(GetParentCategoryName());
            return GetParentCategoryNameOrderByChildCatgory;
        }

        public List<String> GetParentCategoryName()
        {
            String sql = "SELECT CategoryName FROM Category where Status = '2'";
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
        public void Dispose()
        {

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<Category> ListAllChildCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 2).ToList();
        }
        public List<Category> ListAllParentCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 1).ToList();
        }

        public Category GetCategoryByID(int CategoryId)
        {
            return _context.Category.Find(CategoryId);
        }
        public CategoryEdit GetCategoryEditByID(int CategoryId)
        {
            Category category = GetCategoryByID(CategoryId);
            CategoryEdit categoryEdit = new CategoryEdit()
            {
                CategoryName = category.CategoryName,
                Id = category.CategoryId,
                imageURL = category.imageURL,
                ParentCategoryName = GetCategoryByID(category.ParentId).CategoryName,
                ShortDescription = category.ShortDescription,
                Status = category.Status
            };
            return categoryEdit;
        }

        public async Task UpdateCategory(CategoryEdit categorytEdit)
        {
            if (categorytEdit.Photo != null)
            {

                String uniqueFileName = null;
                String uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\CategoryImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + categorytEdit.Photo.FileName;
                String Url = Path.Combine(uploadFolder, uniqueFileName);
                categorytEdit.Photo.CopyTo(new FileStream(Url, FileMode.Create));
                String filePath = "/CategoryImages/" + uniqueFileName;
                Category category = new Category
                {
                    CategoryId = categorytEdit.Id,
                    CategoryName = categorytEdit.CategoryName,
                    imageURL = filePath,
                    IsShowOnHome = 1,
                    ParentId = GetParentCategoryId(categorytEdit.ParentCategoryNameEdit),
                    ShortDescription = categorytEdit.ShortDescription,
                    SortOrder = 1,
                    Status = categorytEdit.Status

                };
                 _context.Update(category);
                _context.SaveChanges();
            }
            else
            {
                Category category = new Category
                {
                    CategoryId = categorytEdit.Id,
                    CategoryName = categorytEdit.CategoryName,
                    imageURL = categorytEdit.imageURL,
                    IsShowOnHome = 1,
                    ParentId = GetParentCategoryId(categorytEdit.ParentCategoryNameEdit),
                    ShortDescription = categorytEdit.ShortDescription,
                    SortOrder = 1,
                    Status = 1

                };
                _context.Update(category);
                await _context.SaveChangesAsync();
            }

        }


    }
}

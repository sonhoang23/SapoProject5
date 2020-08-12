using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface ICategoryRepository : IDisposable
    {
        Task CreateCategory(CategoryCreate categoryCreate);
        List<Category> ListAllChildCategory();
        List<Category> ListAllParentCategory();
        List<String> GetParentCategoryName();
        Task UpdateCategory(CategoryEdit categorytEdit);
        Category GetCategoryByID(int CategoryId);
        CategoryEdit GetCategoryEditByID(int CategoryId);
        String GetCategoryNameById(int Id);
        int GetParentCategoryIdByChildCategoryId(int Id);
        List<String> GetParentCategoryNameOrderByChildCatgory(int Id);
        void Save();
        void Dispose();

    }
}

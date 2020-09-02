using SapoProject.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using SapoProject.Model.Entities;
namespace SapoProject.Areas.Customer.Repository.Interface
{
    public interface ISharedCustomerRepository : IDisposable
    {
        List<Category> ListAllChildCategory();
        List<Category> ListAllParentCategory();
        void Save();
        void Dispose();
        List<AdvertisementSlideShow> GetAdvertisementSlideShow();
    }
}

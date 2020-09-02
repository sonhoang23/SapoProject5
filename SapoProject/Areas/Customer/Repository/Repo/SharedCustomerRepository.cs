using SapoProject.Model.Data;
using SapoProject.Model.Entities;
using SapoProject.Areas.Customer.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SapoProject.Areas.Customer.Repository.Repo
{
    public class SharedCustomerRepository : ISharedCustomerRepository
    {
        private readonly SapoProjectDbContext _context;

        public SharedCustomerRepository(SapoProjectDbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {

        }

        public List<AdvertisementSlideShow> GetAdvertisementSlideShow()
        {
            return _context.AdvertisementSlideShows.Where(x => x.Status != 0 && x.CompletedDate>= DateTime.Now).ToList();
        }

        public List<Category> ListAllChildCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 2).ToList();
        }
        public List<Category> ListAllParentCategory()
        {
            return _context.Category.Where(x => x.Status != 0 && x.Status != 1).ToList();
        }

        public void Save()
        {
           
        }
    }
}
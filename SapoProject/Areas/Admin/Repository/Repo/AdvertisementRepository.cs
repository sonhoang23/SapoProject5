using Microsoft.Extensions.Hosting;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model;
using SapoProject.Model.Data;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;

        public AdvertisementRepository(SapoProjectDbContext context, IHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();

        }

        public bool CheckCreateAndCompletedDate(DateTime dateCreated, DateTime completedDate)
        {
            int res = DateTime.Compare(dateCreated, completedDate);
            if (res <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task CreateAdvertisement(AdvertisementCreate advertisementCreate)
        {
            string uniqueFileName = null;


            String uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\Image\\Advertisement\\ImageSlideShow");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + advertisementCreate.Photo.FileName;
            String Url = Path.Combine(uploadFolder, uniqueFileName);
            advertisementCreate.Photo.CopyTo(new FileStream(Url, FileMode.Create));
            String filePath = "/Image/Advertisement/ImageSlideShow/" + uniqueFileName;
            AdvertisementSlideShow newAdvertisementCreate = new AdvertisementSlideShow
            {
                AdvertisementName = advertisementCreate.AdvertisementName,
                AdvertisementShortDescription = advertisementCreate.AdvertisementShortDescription,
                AdvertisementLongDescription = advertisementCreate.AdvertisementLongDescription,
                AdvertisementDestination = advertisementCreate.AdvertisementDestination,
                DateCreated = advertisementCreate.DateCreated,
                CompletedDate = advertisementCreate.CompletedDate,
                AdvertisementImageUrl = filePath,
                Status = advertisementCreate.Status,
            };

            await _context.AddAsync(newAdvertisementCreate);
            await _context.SaveChangesAsync();
        }
    }
}

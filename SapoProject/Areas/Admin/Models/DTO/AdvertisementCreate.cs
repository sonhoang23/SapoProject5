using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class AdvertisementCreate
    {
        public int Id { set; get; }
        public String AdvertisementName { set; get; }
        public String AdvertisementShortDescription { set; get; }
        public String AdvertisementLongDescription { set; get; }
        public IFormFile Photo { set; get; }
        public String AdvertisementDestination { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime CompletedDate { set; get; }
        public int Status { set; get; }
    }
}

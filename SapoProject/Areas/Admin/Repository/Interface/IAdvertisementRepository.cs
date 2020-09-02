using SapoProject.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IAdvertisementRepository
    {
        Task CreateAdvertisement(AdvertisementCreate advertisementCreate);
        bool CheckCreateAndCompletedDate(DateTime dateCreated, DateTime completedDate);
    }
}

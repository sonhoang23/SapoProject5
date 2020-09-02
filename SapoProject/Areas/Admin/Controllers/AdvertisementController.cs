using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Controllers
{
    public class AdvertisementController : BaseController
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public AdvertisementController(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        [HttpGet]
        public IActionResult CreateAdvertisement()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdvertisementAsync(AdvertisementCreate advertisementCreate)
        {
            if (ModelState.IsValid)
            {
                if (_advertisementRepository.CheckCreateAndCompletedDate(advertisementCreate.DateCreated, advertisementCreate.CompletedDate) == true)
                {
                    await _advertisementRepository.CreateAdvertisement(advertisementCreate);
                    TempData["Message"] = "Create Advertisement Completely";
                    return RedirectToAction("CreateAdvertisement");
                }
                else
                {
                    TempData["Message"] = "Check Completed Date";
                    return View("CreateAdvertisement", advertisementCreate);
                }
            }
            else
            {
                TempData["Message"] = "aaaaaaaaaaaaa";
                return View("CreateAdvertisement", advertisementCreate);
            }
        }
        [HttpGet]
        public IActionResult IndexAdvertisemnt()
        {
            return View();
        }

    }
}

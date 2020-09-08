using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Editor Advertisement")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ILogger _logger;
        public AdvertisementController(IAdvertisementRepository advertisementRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _advertisementRepository = advertisementRepository;
        }
        [HttpGet]
        public IActionResult CreateAdvertisement()
        {
            _logger.LogInformation("Log message in the Index() method");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdvertisement(AdvertisementCreate advertisementCreate)
        {
            if (ModelState.IsValid)
            {
                if (_advertisementRepository.CheckCreateAndCompletedDate(advertisementCreate.DateCreated, advertisementCreate.CompletedDate) == true)
                {
                    ViewData["Title"] = "Tạo Quảng Cáo";
                    await _advertisementRepository.CreateAdvertisement(advertisementCreate);
                    TempData["Message"] = "Tạo Quảng Cáo Thành Công";
                    return RedirectToAction("CreateAdvertisement");
                }
                else
                {
                    TempData["Message"] = "Kiểm Tra Lại Ngày Hoàn Thành";
                    return View("CreateAdvertisement", advertisementCreate);
                }
            }
            else
            {
                TempData["Message"] = "Mời Kiểm Tra Lại Thông Tin Nhập";
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

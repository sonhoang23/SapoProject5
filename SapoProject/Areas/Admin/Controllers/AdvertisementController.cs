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

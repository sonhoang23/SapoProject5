using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class AdvertisementSlideShowViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public AdvertisementSlideShowViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {

            string MyView = "_PartialView_SlideProduct";
            //string MyView = "_PartialView_Footer";
            List<AdvertisementSlideShow> advertisementSlideShows = _sharedRepository.GetAdvertisementSlideShow();
              return View(MyView, advertisementSlideShows);
            //return View(MyView);
        }

    }
}
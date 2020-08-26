using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class MainSearchViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public MainSearchViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "_PartialView_MainSearch";
            return View(MyView);

        }

    }
}
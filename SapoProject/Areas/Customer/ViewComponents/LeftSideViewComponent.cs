using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class LeftSideViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public LeftSideViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "_PartialView_SideLeft";
            return View(MyView);
        }

    }
}
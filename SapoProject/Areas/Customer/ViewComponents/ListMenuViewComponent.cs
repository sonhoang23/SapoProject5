using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class ListMenuViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public ListMenuViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "_PartialView_ListMenu";
            return View(MyView, _sharedRepository.ListAllChildCategory());
        }

    }
}

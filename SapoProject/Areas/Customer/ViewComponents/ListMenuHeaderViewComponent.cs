using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class ListMenuHeaderViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public ListMenuHeaderViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            if (HttpContext.Session.GetString("clientAccount") == null || HttpContext.Session.GetInt32("status") == null)
            {
                string MyView = "_PartialView_ListMenuHeader";
                return View(MyView, _sharedRepository.ListAllChildCategory());
            }
            else
            {
               string MyView = "_PartialView_ListMenuHeader_Login";
               
                return View(MyView);
            }

           
        }

    }
}

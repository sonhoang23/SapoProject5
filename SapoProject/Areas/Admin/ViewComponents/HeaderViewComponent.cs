using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Model.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;


namespace SapoProject.Areas.Admin.ViewComponents
{
    //  [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISharedRepository _sharedRepository;

        public HeaderViewComponent(ISharedRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }
        /* public PartialViewResult PartialView_Header()
         {
             ViewBag.TerritoryID = "Hoang Son";

             return PartialView();
         }*/
        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "PartialView_Header";
            return View(MyView, _sharedRepository.getUserLogin());
        }

    }
}

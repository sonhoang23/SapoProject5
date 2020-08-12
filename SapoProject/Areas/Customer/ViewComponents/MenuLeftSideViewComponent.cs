using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Customer.Repository.Interface;

namespace SapoProject.Areas.Customer.ViewComponents
{
    //  [ViewComponent(Name = "Header")]
    public class MenuLeftSideViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public MenuLeftSideViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "_PartialView_CategoryMenu";
            return View(MyView, _sharedRepository.ListAllChildCategory());
        }

    }
}

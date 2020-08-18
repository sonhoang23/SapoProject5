using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Repository.Interface;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.ViewComponents
{
    public class MainHeaderViewComponent : ViewComponent
    {
        private readonly ISharedCustomerRepository _sharedRepository;

        public MainHeaderViewComponent(ISharedCustomerRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         int maxPriority, bool isDone)
        {
            string MyView = "_PartialView_Header";
            return  View(MyView);
        }
       
    }
}
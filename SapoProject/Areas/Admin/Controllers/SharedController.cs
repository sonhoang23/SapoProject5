using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;


namespace SapoProject.Areas.Admin.Controllers
{

    public class ShareController : BaseController
    {
     
        public PartialViewResult PartialView_Header()
        {
            ViewBag.TerritoryID = "Hoang Son";

            return PartialView();
        }

        
    }
}
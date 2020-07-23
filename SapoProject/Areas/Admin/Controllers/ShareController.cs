using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ShareController : Controller
    {
        public IActionResult PartialViewLayoutSideLeft() =>
      new PartialViewResult
      {
          ViewName = "_AuthorPartialRP",
          ViewData = ViewData,
      };

    }
}

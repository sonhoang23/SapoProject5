using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SapoProject.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public async Task OnActionExecutionAsync(
          ActionExecutingContext context,
          ActionExecutionDelegate next)
        {
            if (HttpContext.Session.GetString("username") == null)
            {

            }
                // Do something before the action executes.

                // next() calls the action method.
                var resultContext = await next();
            // resultContext.Result is set.
            // Do something after the action executes.
        }
    }
}

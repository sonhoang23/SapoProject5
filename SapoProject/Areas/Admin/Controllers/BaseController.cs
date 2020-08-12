using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace SapoProject.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext
                                               context)
        {
            if (context.HttpContext.Session.GetString("userAccount") == null || context.HttpContext.Session.GetInt32("status") == null)
            {
                context.Result = new RedirectToRouteResult(
                  new RouteValueDictionary
                  {
                    { "controller", "User" },
                    { "action", "Login" }
                  });
            }
        }
        public override void OnActionExecuted(ActionExecutedContext
                                              context)
        {

        }
    }
}

/* : Controller
{

 public async Task OnActionExecutionAsync(
                  ActionExecutingContext context,
                  ActionExecutionDelegate next)
 {
     // Do something before the action executes.
     if (context.HttpContext.Session.GetString("userAccount") == null || context.HttpContext.Session.GetInt32("status") == null)
     {
         context.Result = new RedirectToRouteResult(
           new RouteValueDictionary
           {
                    { "controller", "User" },
                    { "action", "Login" }
           });

     }
     // next() calls the action method.
     var resultContext = await next();
     // resultContext.Result is set.
     // Do something after the action executes.
 }

}
}
   */

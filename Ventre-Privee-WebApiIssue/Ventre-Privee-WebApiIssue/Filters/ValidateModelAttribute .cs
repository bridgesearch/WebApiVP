using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ventre_Privee_WebApiIssue.Filters
{
    public class ValidateUserParameter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult("User parameter is required");
                
                return;
            }
        }
    }
}

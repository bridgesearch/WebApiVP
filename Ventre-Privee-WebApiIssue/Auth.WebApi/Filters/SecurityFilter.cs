using Auth.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Auth.WebApi.Filters
{
    public class SecurityFilter : Attribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
          if(!ValidateAuthHeader(context.HttpContext.Request))
            {
                  context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new UnauthorizedResult();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string BuildRequestSignature(HttpRequest request)
        {

            string signstring = string.Format("{0}_{1}_{2}", request.Method, request.ContentType, DateTime.Now.ToString("ddMMyyyy"));
            signstring = string.Format("VP {0}:{1}", Helpers.Constants.VPAccessKeyId, signstring);

            return signstring;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        private bool ValidateAuthHeader(HttpRequest request)
        {
            
            string clientauthorizationstring = request.Headers["Authorization"];
            string serverauthorizationstring = BuildRequestSignature(request);

            return serverauthorizationstring.Equals(clientauthorizationstring);

        }
    }
}

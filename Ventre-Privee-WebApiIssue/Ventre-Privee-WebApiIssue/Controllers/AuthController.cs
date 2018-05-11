using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Auth.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventre_Privee_WebApiIssue.Filters;

namespace Ventre_Privee_WebApiIssue.Controllers
{
    [Produces("application/json")]
    [Route("Auth/api/")]
    public class AuthController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepo _user;
        public AuthController(IUserRepo user) {
            _user = user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        [ValidateUserParameter]
        public async Task<ActionResult> Authenticate([FromBody] User creds) {

            var UserExists = await Task.Run(() => _user.ValidateUser(creds));
            return Ok(UserExists);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("confidentials")]
        public async Task<ActionResult> Confidentials(string email)
        {
            return Ok(null);
        }
    }
}
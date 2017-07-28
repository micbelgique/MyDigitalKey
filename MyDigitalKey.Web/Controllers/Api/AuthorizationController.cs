using System;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;

namespace MyDigitalKey.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        // GET api/isauthorized
        [HttpGet]
        public bool IsAuthorized(int digitalKeyBusinessId, Guid lockId)
        {
            Console.WriteLine("HAHAHAHAH");
            return authorizationService.IsAuthorized(digitalKeyBusinessId, lockId);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

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

        // GET api/authorization
        [HttpGet]
        [Route("{lockId}/{digitalKeyBusinessId}")]
        public bool IsAuthorized(Guid lockId, int digitalKeyBusinessId)
        {
            return authorizationService.IsAuthorized(lockId, digitalKeyBusinessId);
        }

        // GET api/authorization
        [HttpGet]
        public IEnumerable<AuthorizationDto> Get()
        {
            return authorizationService.FindAll();
        }
    }
}
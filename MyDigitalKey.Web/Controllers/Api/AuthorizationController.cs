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
        [HttpGet()]
        [Route("{digitalKeyBusinessId}/{lockId}")]
        public bool IsAuthorized(int digitalKeyBusinessId, Guid lockId)
        {
            return authorizationService.IsAuthorized(digitalKeyBusinessId, lockId);
        }


        // GET api/authorization
        [HttpGet]
        public IEnumerable<AuthorizationDto> Get()
        {
            return authorizationService.FindAll();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyDigitalKey.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/authorization")]
    public class AuthorizationApiController : Controller
    {
        private readonly IAuthorizationService authorizationService;

        public AuthorizationApiController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }
    }
}
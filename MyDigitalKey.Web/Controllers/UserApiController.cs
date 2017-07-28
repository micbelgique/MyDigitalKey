using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/UserApi")]
    public class UserApiController : Controller
    {
        private readonly IUserService userService;

        public UserApiController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return userService.GetAll();
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/user
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return userService.FindAll();
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] UserDto user)
        {
            userService.Add(user);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/lock")]
    public class LockController : Controller
    {
        private readonly ILockService lockService;

        public LockController(ILockService lockService)
        {
            this.lockService = lockService;
        }

        // POST api/lock
        [HttpPost]
        public void Post([FromBody] LockDto lockDto)
        {
            lockService.Register(lockDto.Id,lockDto.Name);
        }

        // GET api/lock
        [HttpGet]
        public IEnumerable<LockDto> Get()
        {
            return lockService.FindAll();
        }
    }
}
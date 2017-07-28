using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/digitalkey")]
    public class DigitalKeyApiController : Controller
    {
        private readonly IDigitalKeyService digitalKeyService;

        public DigitalKeyApiController(IDigitalKeyService digitalKeyService)
        {
            this.digitalKeyService = digitalKeyService;
        }

        // POST api/digitalkey
        [HttpPost]
        public void Post([FromBody] DigitalKeyDto digitalKey)
        {
            digitalKeyService.Register(digitalKey.Id);
        }
    }
}
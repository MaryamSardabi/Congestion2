using Congestion.Api.ViewModels;
using Congestion.Application;
using Microsoft.AspNetCore.Mvc;

namespace Congestion.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TollRegistrationController : ControllerBase
    {
        private readonly ITollRegistrationService _tollRegistrationService;
        public TollRegistrationController(ITollRegistrationService tollRegistrationService)
        {
            _tollRegistrationService = tollRegistrationService;
        }

        [HttpPost]
        public async Task<ActionResult> AddTollRegistration([FromQuery] TollRegistrationVm request , CancellationToken ct=default)
        {
            await _tollRegistrationService.AddTollRegistraionAsync(request.CityId, request.CongestionId,request.Tag, ct);
            return Ok();

        }
     



    }
}

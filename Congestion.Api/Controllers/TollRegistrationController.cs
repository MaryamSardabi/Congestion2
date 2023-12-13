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
        [HttpGet]
        public async Task<ActionResult> AddTollRegistration([FromQuery] TollRegistrationVm request)
        {
            await _tollRegistrationService.AddTollRegistraion(request.CityId, request.CongestionId,request.Tag, CancellationToken.None);
            return Ok();

        }



        [HttpGet]
        public async Task<IActionResult> GetTollRegistration(int tollRegistrationId)
        {
            var item = await _tollRegistrationService.GetById(tollRegistrationId, CancellationToken.None);
            return Ok(item);

        }



    }
}

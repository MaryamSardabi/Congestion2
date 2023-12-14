using Congestion.Api.ViewModels;
using Congestion.Application;
using Microsoft.AspNetCore.Mvc;

namespace Congestion.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost]
        public async Task<ActionResult> AddCar([FromQuery] CarVm request, CancellationToken ct)
        {
            await _carService.AddCarAsync(request.Tag, request.CarTypeId, ct);
            return Ok();
            
        }
    }
}

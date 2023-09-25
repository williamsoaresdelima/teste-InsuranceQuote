using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuote.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly ISaveVehicleUseCase _saveVehicleUseCase;

        public VehicleController(ISaveVehicleUseCase saveVehicleUseCase)
            =>_saveVehicleUseCase = saveVehicleUseCase;

        [HttpPost("SaveVehicle")]
        public async Task<IActionResult> SaveVehicle(SaveVehiclesRequest request)
            => Ok(await _saveVehicleUseCase.SaveVehicle(request));
    }
}
using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuote.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : Controller
    {
        private readonly ISaveInsuranceUseCase _saveInsuranceUseCase;
        private readonly ICalculateInsuranceUseCase _calculateInsuranceUseCase;
        private readonly IGetInsuranceDataUseCase _getInsuranceDataUseCase;
        private readonly IGetReportInsuranceUseCase _getReportInsuranceUseCase;

        public InsuranceController(
            ISaveInsuranceUseCase saveInsuranceUseCase,
            ICalculateInsuranceUseCase calculateInsuranceUseCase,
            IGetInsuranceDataUseCase getInsuranceDataUseCase,
            IGetReportInsuranceUseCase getReportInsuranceUseCase)
        {
            _saveInsuranceUseCase = saveInsuranceUseCase;
            _calculateInsuranceUseCase = calculateInsuranceUseCase;
            _getInsuranceDataUseCase = getInsuranceDataUseCase;
            _getReportInsuranceUseCase = getReportInsuranceUseCase;
        }

        [HttpPost("SaveInsurance")]
        public async Task<IActionResult> SaveInsurance(SaveInsuranceRequest request)
            => Ok(await _saveInsuranceUseCase.SaveInsurance(request));

        [HttpGet("CalculateInsuranceVehicle")]
        public async Task<IActionResult> CalculateInsuranceVehicle(int vehicleId)
            => Ok(await _calculateInsuranceUseCase.CalculateInsuranceVehicle(vehicleId));

        [HttpGet("GetInsuranceData")]
        public async Task<IActionResult> GetInsuranceData(int insuranceId)
            => Ok(await _getInsuranceDataUseCase.GetInsuranceData(insuranceId));

        [HttpGet("GetReportInsurance")]
        public async Task<IActionResult> GetReportInsurance()
            => Ok(await _getReportInsuranceUseCase.GetReportInsurance());
    }
}
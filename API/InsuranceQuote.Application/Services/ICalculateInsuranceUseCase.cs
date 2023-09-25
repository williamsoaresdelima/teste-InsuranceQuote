using InsuranceQuote.Application.Dto;

namespace InsuranceQuote.Application.Services
{
    public interface ICalculateInsuranceUseCase
    {
        Task<QuoteDTO> CalculateInsuranceVehicle(int vehicleId);
    }
}
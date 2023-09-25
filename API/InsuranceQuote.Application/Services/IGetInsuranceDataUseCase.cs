using InsuranceQuote.Application.Dto;

namespace InsuranceQuote.Application.Services
{
    public interface IGetInsuranceDataUseCase
    {
        Task<InsuranceResponse> GetInsuranceData(int insuranceId);
    }
}
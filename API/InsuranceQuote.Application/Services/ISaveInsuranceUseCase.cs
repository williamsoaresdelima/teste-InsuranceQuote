using InsuranceQuote.Application.Dto;

namespace InsuranceQuote.Application.Services
{
    public interface ISaveInsuranceUseCase
    {
        Task<string> SaveInsurance(SaveInsuranceRequest request);
    }
}
using InsuranceQuote.Application.Dto;

namespace InsuranceQuote.Application.Services
{
    public interface IGetReportInsuranceUseCase
    {
        Task<ReportInsuranceResponse> GetReportInsurance();
    }
}
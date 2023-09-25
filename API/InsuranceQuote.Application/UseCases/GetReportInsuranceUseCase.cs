using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;

namespace InsuranceQuote.Application.UseCases
{
    public class GetReportInsuranceUseCase : IGetReportInsuranceUseCase
    {
        private readonly IRepositoryBase<Quote> _quoteRepository;
        private readonly IRepositoryBase<Vehicles> _vehiclesRepository;
        private readonly IRepositoryBase<Insurance> _insuranceRepository;

        public GetReportInsuranceUseCase(
            IRepositoryBase<Quote> quoteRepository,
            IRepositoryBase<Vehicles> vehiclesRepository,
            IRepositoryBase<Insurance> insuranceRepository)
        {
            _quoteRepository = quoteRepository;
            _vehiclesRepository = vehiclesRepository;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<ReportInsuranceResponse> GetReportInsurance()
        {
            ReportInsuranceResponse result = new ReportInsuranceResponse();
            result.Data = new List<InsuranceDataDTO>();

            var insures = await _insuranceRepository.GetAllAsync();
            var vehicles = await _vehiclesRepository.GetAllAsync();
            var quotes = await _quoteRepository.GetAllAsync();

            foreach (var insure in insures)
            {
                var vehicle = vehicles.FirstOrDefault(x => x.Id == insure.VehicleId);
                var quote = quotes.FirstOrDefault(x => x.InsuranceId == insure.Id);

                result.AvgPurePrize += quote.PurePrize;
                result.AvgRiskRate += quote.RiskRate;
                result.AvgRiskPremium += quote.RiskPremium;
                result.AvgCommercialAward += quote.CommercialAward;

                result.Data.Add(new InsuranceDataDTO()
                {
                    Id = insure.Id,
                    Age = insure.Age,
                    Name = insure.Name,
                    DocumentNumber = insure.DocumentNumber,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Value = vehicle.Price,
                    CommercialAward = quote.CommercialAward,
                    PurePrize = quote.PurePrize,
                    RiskPremium = quote.RiskPremium,
                    RiskRate = quote.RiskRate
                });
            }

            result.AvgPurePrize = result.AvgPurePrize / insures.Count();
            result.AvgRiskRate = result.AvgRiskRate / insures.Count();
            result.AvgRiskPremium = result.AvgRiskPremium / insures.Count();
            result.AvgCommercialAward = result.AvgCommercialAward / insures.Count();

            return result;
        }
    }
}
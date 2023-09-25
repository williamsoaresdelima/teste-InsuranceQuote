using AutoMapper;
using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;

namespace InsuranceQuote.Application.UseCases
{
    public class GetInsuranceDataUseCase : IGetInsuranceDataUseCase
    {
        private readonly IRepositoryBase<Quote> _quoteRepository;
        private readonly IRepositoryBase<Vehicles> _vehiclesRepository;
        private readonly IRepositoryBase<Insurance> _insuranceRepository;
        private readonly IMapper _mapper;

        public GetInsuranceDataUseCase(
            IRepositoryBase<Quote> quoteRepository,
            IRepositoryBase<Vehicles> vehiclesRepository,
            IRepositoryBase<Insurance> insuranceRepository,
            IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _vehiclesRepository = vehiclesRepository;
            _insuranceRepository = insuranceRepository;
            _mapper = mapper;
        }

        public async Task<InsuranceResponse> GetInsuranceData(int insuranceId)
        {
            try
            {
                var insurance = await _insuranceRepository.GetByIdAsync(insuranceId);

                var vehicle = await _vehiclesRepository.GetByIdAsync(insurance.VehicleId);

                var quotesList = await _quoteRepository.GetAllAsync();
                var quote = quotesList.FirstOrDefault(x => x.InsuranceId == insuranceId);

                return new InsuranceResponse(insurance, quote, vehicle, _mapper);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
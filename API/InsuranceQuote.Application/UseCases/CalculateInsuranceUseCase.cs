using AutoMapper;
using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;

namespace InsuranceQuote.Application.UseCases
{
    public class CalculateInsuranceUseCase : ICalculateInsuranceUseCase
    {
        private readonly IRepositoryBase<Vehicles> _vehiclesRepository;
        private readonly IMapper _mapper;

        public CalculateInsuranceUseCase(
            IRepositoryBase<Vehicles> vehiclesRepository,
            IMapper mapper)
        {
            _vehiclesRepository = vehiclesRepository;
            _mapper = mapper;
        }

        public async Task<QuoteDTO> CalculateInsuranceVehicle(int vehicleId)
        {
            try
            {
                var vehicle = await _vehiclesRepository.GetByIdAsync(vehicleId);

                if (vehicle == null) { return null; }

                var quote = new Quote();
                quote.CalculateQuote(vehicle);

                return _mapper.Map<QuoteDTO>(quote);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
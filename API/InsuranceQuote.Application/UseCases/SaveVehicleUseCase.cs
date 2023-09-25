using AutoMapper;
using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;

namespace InsuranceQuote.Application.UseCases
{
    public class SaveVehicleUseCase : ISaveVehicleUseCase
    {
        private readonly IRepositoryBase<Vehicles> _vehicleRepository;
        private readonly IMapper _mapper;

        public SaveVehicleUseCase(
            IRepositoryBase<Vehicles> vehicleRepository,
            IMapper mapper
            )
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<int> SaveVehicle(SaveVehiclesRequest resquest)
        {
            try
            {
                var vehicleDto = new VehiclesDTO(resquest);
                return await _vehicleRepository.AddAsync(_mapper.Map<Vehicles>(vehicleDto));
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
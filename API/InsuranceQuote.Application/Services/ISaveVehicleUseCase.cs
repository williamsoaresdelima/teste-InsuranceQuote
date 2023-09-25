using InsuranceQuote.Application.Dto;

namespace InsuranceQuote.Application.Services
{
    public interface ISaveVehicleUseCase
    {
        Task<int> SaveVehicle(SaveVehiclesRequest resquest);
    }
}
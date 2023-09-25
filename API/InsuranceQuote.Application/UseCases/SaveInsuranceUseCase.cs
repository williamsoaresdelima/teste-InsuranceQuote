using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;
using Newtonsoft.Json;

namespace InsuranceQuote.Application.UseCases
{
    public class SaveInsuranceUseCase : ISaveInsuranceUseCase
    {
        private readonly IRepositoryBase<Quote> _quoteRepository;
        private readonly IRepositoryBase<Vehicles> _vehiclesRepository;
        private readonly IRepositoryBase<Insurance> _insuranceRepository;

        public SaveInsuranceUseCase(
            IRepositoryBase<Quote> quoteRepository,
            IRepositoryBase<Vehicles> vehiclesRepository,
            IRepositoryBase<Insurance> insuranceRepository)
        {
            _quoteRepository = quoteRepository;
            _vehiclesRepository = vehiclesRepository;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<string> SaveInsurance(SaveInsuranceRequest request)
        {
            try
            {
                var vehicle = await _vehiclesRepository.GetByIdAsync(request.VehicleId);

                if (vehicle == null) { return "Vehicle not found"; }

                var insured = await GetInsured(request.DocumentNumber);

                if (insured == null) { return "Insured not found"; }

                var insurance = new Insurance()
                {
                    DocumentNumber = request.DocumentNumber,
                    Name = insured.Name,
                    Age = insured.Age,
                    VehicleId = request.VehicleId
                };

                var idInsurance = await _insuranceRepository.AddAsync(insurance);

                var quote = new Quote() { InsuranceId = idInsurance };
                quote.CalculateQuote(vehicle);

                await _quoteRepository.AddAsync(quote);

                return "Success";
            }
            catch
            {
                return "Failed to save insurance!";
            }
        }

        private async Task<InsuredResponse> GetInsured(string documentNumber)
        {
            string url = $"https://localhost:7213/Insured?documentNumber={documentNumber}";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string res = await content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(res)) return null;

                return JsonConvert.DeserializeObject<InsuredResponse>(res);
            }
        }
    }
}
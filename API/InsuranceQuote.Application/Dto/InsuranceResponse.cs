using AutoMapper;
using InsuranceQuote.Domain.Entities;

namespace InsuranceQuote.Application.Dto
{
    public class InsuranceResponse
    {
        public InsuranceResponse(Insurance insurance, Quote quote, Vehicles vehicle, IMapper _mapper)
        {
            this.QuoteId = quote.Id;
            this.VehicleId = vehicle.Id;
            this.DocumentNumber = insurance.DocumentNumber;
            this.Name = insurance.Name;
            this.Age = insurance.Age;
            this.Quote = _mapper.Map<QuoteDTO>(quote);
            this.Vehicle = _mapper.Map<VehiclesDTO>(vehicle);
        }

        public int Id { get; private set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int VehicleId { get; set; }
        public int QuoteId { get; set; }

        public VehiclesDTO Vehicle { get; set; }
        public QuoteDTO Quote { get; set; }
    }
}
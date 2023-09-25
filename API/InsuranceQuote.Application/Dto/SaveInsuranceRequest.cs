using InsuranceQuote.Domain.Entities;

namespace InsuranceQuote.Application.Dto
{
    public class SaveInsuranceRequest
    {
        public int VehicleId { get; set; }
        public string DocumentNumber { get; set; }
    }
}
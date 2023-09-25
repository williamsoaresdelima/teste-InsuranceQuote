using System.ComponentModel.DataAnnotations;

namespace InsuranceQuote.Domain.Entities
{
    public class Insurance 
    {
        [Key]
        public int Id { get; private set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int VehicleId { get; set; }

        public Vehicles Vehicle { get; set; }
        public Quote Quote { get; set; }
    }
}
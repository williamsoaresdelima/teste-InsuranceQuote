using System.ComponentModel.DataAnnotations;

namespace InsuranceQuote.Domain.Entities
{
    public class Vehicles 
    {
        [Key]
        public int Id { get; private set; }
        public decimal Price { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<Insurance> Insurances { get; set; }
    }
}
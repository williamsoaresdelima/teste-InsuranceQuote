using System.ComponentModel.DataAnnotations;

namespace InsuranceQuote.Domain.Entities
{
    public class Quote
    {
        [Key]
        public int Id { get; private set; }
        public int InsuranceId { get; set; }
        public decimal RiskRate { get; set; }
        public decimal RiskPremium { get; set; }
        public decimal PurePrize { get; set; }
        public decimal CommercialAward { get; set; }

        public Insurance Insurance { get; set; }

        public void CalculateQuote(Vehicles vehicle)
        {
            decimal secureMargin = Convert.ToDecimal("0,03");
            decimal profit = Convert.ToDecimal("0,05");

            this.RiskRate = (vehicle.Price * 5) / (2 * vehicle.Price);
            this.RiskPremium = ((vehicle.Price * this.RiskRate) / 100);
            this.PurePrize = (this.RiskPremium * (1 + secureMargin));
            this.CommercialAward = ((profit + 1) * this.PurePrize);
        }
    }
}
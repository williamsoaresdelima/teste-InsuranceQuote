namespace InsuranceQuote.Application.Dto
{
    public class QuoteDTO
    {
        public decimal RiskRate { get; set; }
        public decimal RiskPremium { get; set; }
        public decimal PurePrize { get; set; }
        public decimal CommercialAward { get; set; }
    }
}
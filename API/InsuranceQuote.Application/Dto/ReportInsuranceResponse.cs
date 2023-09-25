namespace InsuranceQuote.Application.Dto
{
    public class ReportInsuranceResponse
    {
        public decimal AvgRiskRate { get; set; }
        public decimal AvgRiskPremium { get; set; }
        public decimal AvgPurePrize { get; set; }
        public decimal AvgCommercialAward { get; set; }
        public List<InsuranceDataDTO> Data { get; set; }
    }

    public class InsuranceDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int Age { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public decimal RiskRate { get; set; }
        public decimal RiskPremium { get; set; }
        public decimal PurePrize { get; set; }
        public decimal CommercialAward { get; set; }
    }
}
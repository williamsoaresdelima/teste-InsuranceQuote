using InsuranceQuote.Domain.Entities;

namespace InsuranceQuote.Tests
{
    [TestClass]
    public class InsuranceQuoteTest
    {
        [TestMethod]
        public void CalculateQuote()
        {
            decimal commercialAwardExpect = Convert.ToDecimal("270,37500");

            Vehicles vehicle = new Vehicles()
            {
                Make = "Test",
                Model = "Test",
                Price = 10000
            };

            Quote quote = new Quote();
            quote.CalculateQuote(vehicle);

            Assert.AreEqual(commercialAwardExpect, quote.CommercialAward);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuote.Insured.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuredController : ControllerBase
    {
        public InsuredController() { }

        private List<Insured> insureds = new List<Insured>()
            {
                new Insured("Maria", "74856774034", 35),
                new Insured("João", "78592155002", 38),
                new Insured("William", "06613931004", 32),
                new Insured("Noah", "87321421023", 18)
            };

        [HttpGet(Name = "GetByDocumentInsured")]
        public Insured? GetByDocument(string documentNumber)
            => insureds.FirstOrDefault(x => x.DocumentNumber == documentNumber);
    }
}
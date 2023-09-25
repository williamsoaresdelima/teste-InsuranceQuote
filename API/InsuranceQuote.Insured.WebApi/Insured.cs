namespace InsuranceQuote.Insured.WebApi
{
    public class Insured
    {
        public Insured(string name, string document, int age)
        {
            Name = name;
            DocumentNumber = document;
            Age = age;
        }

        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int Age { get; set; }
    }
}
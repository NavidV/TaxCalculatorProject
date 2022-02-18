namespace TaxCalculatorService.APIPrpject.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CongestionTax> Taxes { get; set; }
    }
}

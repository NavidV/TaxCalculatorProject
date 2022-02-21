using TaxCalculatorService.APIProject.Helpers;

namespace TaxCalculatorService.APIPrpject.Models
{
    public class SelectedCity
    {
        public int Id { get; set; }
        public Enums.CitiesEnum City { get; set; }
        public IEnumerable<CongestionTax> Taxes { get; set; }
    }
}

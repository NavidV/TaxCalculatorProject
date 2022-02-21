using DataService.APIProject.Helpers;

namespace DataService.APIProject.Models
{
    public class SelectedCity
    {
        public int Id { get; set; }
        public Enums.CitiesEnum City { get; set; }
        public IEnumerable<CongestionTax> Taxes { get; set; }
    }
}

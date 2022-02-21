using DataService.APIProject.Helpers;

namespace DataService.APIProject.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public Enums.VehiclesEnum Vehicle { get; set; }
        public bool IsTaxFree { get; set; }
    }
}

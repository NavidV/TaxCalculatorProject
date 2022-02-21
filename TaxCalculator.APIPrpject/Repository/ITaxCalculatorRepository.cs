using TaxCalculatorService.APIPrpject.Models;

namespace TaxCalculator.ServicesAPI.Repository
{
    public interface ITaxCalculatorRepository
    {
        IEnumerable<VehicleType> GetVehicleTypes();
        double GetTotalTax(VehicleType vehicle, DateTime[] dates, SelectedCity city);
    }
}

using TaxCalculatorService.APIPrpject.Models;

namespace TaxCalculator.ServicesAPI.Repository
{
    public interface ITaxCalculatorRepository
    {
        SelectedCity GetCity(int id);
        IEnumerable<VehicleType> GetVehicleTypes();
        double GetTotalTax(VehicleType vehicle, DateTime[] dates, SelectedCity city);
    }
}

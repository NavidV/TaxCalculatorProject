using TaxCalculatorService.APIPrpject.Models;

namespace TaxCalculator.ServicesAPI.Repository
{
    public interface ITaxCalculatorRepository
    {
        City GetCity(int id);
        IEnumerable<VehicleType> GetVehicleTypes();
        double GetTotalTax(VehicleType vehicle, DateTime[] dates, string cityName);
    }
}

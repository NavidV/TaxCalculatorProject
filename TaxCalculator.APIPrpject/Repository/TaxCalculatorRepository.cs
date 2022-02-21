using TaxCalculatorService.APIProject.Helpers;
using TaxCalculatorService.APIPrpject.DbContexts;
using TaxCalculatorService.APIPrpject.Models;
using static TaxCalculatorService.APIProject.Helpers.Enums;

namespace TaxCalculator.ServicesAPI.Repository
{
    public class TaxCalculatorRepository : ITaxCalculatorRepository
    {

        private ApplicationDbContext _dbContext;

        public TaxCalculatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            SeedGothenburgData();
        }

        public double GetTotalTax(VehicleType vehicle, DateTime[] dates, SelectedCity city)
        {
            DateTime intervalStart = dates[0];
            double totalFee = 0;

            SelectedCity selectedCity = _dbContext.Cities.SingleOrDefault(c => c.City.Equals(city.City));

            if (selectedCity == null)
                return 0;

            selectedCity.Taxes = _dbContext.TaxFees.Where(c => c.SelectedCityId == selectedCity.Id).ToList();

            foreach (DateTime date in dates)
            {
                double nextFee = GetTaxFee(date, vehicle, selectedCity);
                double tempFee = GetTaxFee(intervalStart, vehicle, selectedCity);

                TimeSpan diffInMillies = date - intervalStart;
                double minutes = diffInMillies.TotalMinutes;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }

            if (totalFee > 60) totalFee = 60;

            return totalFee;
        }
        private double GetTaxFee(DateTime date, VehicleType vehicle, SelectedCity city)
        {
            if (IsTaxFreeDate(date) || IsTaxFreeVehicle(vehicle)) return 0;

            var time = date.TimeOfDay;

            if (city.Taxes.Count() < 1)
                return 0;

            double taxFee = city.Taxes.SingleOrDefault(x => DateTimeHelper.IsBetween(time, x.Start, x.End)).Fee;

            if (taxFee > 0)
            {
                return taxFee;
            }
            return 0;
        }
        private bool IsTaxFreeDate(DateTime date)
        {
            return DateTimeHelper.IsHoliday(date) || DateTimeHelper.IsHoliday(date.AddDays(-1)) ||
                   date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                   date.Month == 7;// July is a free month
        }
        private bool IsTaxFreeVehicle(VehicleType vehicle)
        {
            return _dbContext.VehicleTypes.Any(v => v.Vehicle.Equals(vehicle.Vehicle));
        }

        public SelectedCity GetCity(int id)
        {
            return _dbContext.Cities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<VehicleType> GetVehicleTypes()
        {
            return _dbContext.VehicleTypes.ToList();
        }
        public void SeedGothenburgData()
        {
            var gbg = _dbContext.Cities.SingleOrDefault(c => c.City == CitiesEnum.Gothenburg);

            if (gbg != null)
                return;

            _dbContext.Cities.Add(new SelectedCity
            {
                City = Enums.CitiesEnum.Gothenburg,
                Taxes = new List<CongestionTax>()
                    {
                         new CongestionTax(){  Start=new TimeSpan(06,0,0),End = new TimeSpan(06, 29, 0),Fee=8 },
                         new CongestionTax(){ Start=new TimeSpan(06,30,0),End = new TimeSpan(06, 59, 0),Fee=13 },
                         new CongestionTax(){ Start=new TimeSpan(07,0,0),End = new TimeSpan(07, 59, 0),Fee=18 },
                         new CongestionTax(){ Start=new TimeSpan(08,00,0),End = new TimeSpan(08, 29, 0),Fee=13 },
                         new CongestionTax(){ Start=new TimeSpan(08,30,0),End = new TimeSpan(14, 59, 0),Fee=8 },
                         new CongestionTax(){ Start=new TimeSpan(15,0,0),End = new TimeSpan(15, 29, 0),Fee=13 },
                         new CongestionTax(){ Start=new TimeSpan(15,30,0),End = new TimeSpan(16, 59, 0),Fee=18 },
                         new CongestionTax(){ Start=new TimeSpan(17,00,0),End = new TimeSpan(17, 59, 0),Fee=13 },
                         new CongestionTax(){ Start=new TimeSpan(18,00,0),End = new TimeSpan(18, 29, 0),Fee=13 },
                         new CongestionTax(){ Start=new TimeSpan(18,30,0),End = new TimeSpan(05, 59, 0),Fee=0 }
                    }

            });
            _dbContext.SaveChanges();
        }
    }
}

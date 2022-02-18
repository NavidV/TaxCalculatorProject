using Moq;
using System;
using TaxCalculator.ServicesAPI.Repository;
using TaxCalculatorService.APIProject.Helpers;
using TaxCalculatorService.APIPrpject.DbContexts;
using TaxCalculatorService.APIPrpject.Models;
using Xunit;

namespace TollCalculateService.Test
{
    public class TollCalculatorRepositoryUnitTest
    {
        private readonly TaxCalculatorRepository _repo;
        private readonly Mock<ApplicationDbContext> _context;

        private readonly VehicleType _car = new VehicleType { Name = "car" };
        private readonly VehicleType _emergency = new VehicleType { Name = "emergency" };

        public TollCalculatorRepositoryUnitTest()
        {
            _context = new Mock<ApplicationDbContext>();
            _repo = new TaxCalculatorRepository(_context.Object);
        }

        [Fact]
        public void GetTollFee_Should_Calculate_Toll()
        {
            DateTime[] date = new DateTime[]
             {

                new DateTime(2013, 10, 1, 8, 15, 0),
                new DateTime(2013, 10, 1, 8, 30, 1),
                new DateTime(2013, 10, 1, 8, 45, 2),
                new DateTime(2013, 10, 1, 9, 15, 3),
              };

            var result = _repo.GetTotalTax(_car, date,Enums.CitiesEnum.Gothenburg.ToString());

            Assert.NotEqual(0, result);
        }

        [Fact]
        public void GetTollFee_Should_be_Toll_Free_For_Holidays()
        {
            DateTime[] date = new DateTime[]
            {

                new DateTime(2013, 1, 1, 8, 15, 0),
                new DateTime(2013, 1, 1, 8, 30, 1),
                new DateTime(2013, 1, 1, 8, 45, 2),
                new DateTime(2013, 1, 1, 9, 15, 3),
             };

            var result = _repo.GetTotalTax(_car, date, Enums.CitiesEnum.Gothenburg.ToString());

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetTollFee_Should_be_Toll_Free_For_Special_Vehicle()
        {
            DateTime[] date = new DateTime[]
            {

                new DateTime(2013, 10, 1, 8, 15, 0),
                new DateTime(2013, 10, 1, 8, 30, 1),
                new DateTime(2013, 10, 1, 8, 45, 2),
                new DateTime(2013, 10, 1, 9, 15, 3),
             };

            var result = _repo.GetTotalTax(_car, date, Enums.CitiesEnum.Gothenburg.ToString());

            Assert.Equal(0, result);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using TaxCalculator.ServicesAPI.Repository;
using TaxCalculatorService.APIProject.Helpers;
using TaxCalculatorService.APIPrpject.DbContexts;
using TaxCalculatorService.APIPrpject.Models;

namespace TaxCalxulator.Test
{
    [TestClass]
    public class UnitTests
    {
        private Mock<ApplicationDbContext> _mockc = new Mock<ApplicationDbContext>();

        private readonly VehicleType _car = new VehicleType { Vehicle = Enums.VehiclesEnum.Car };
        private readonly SelectedCity _selectedCity = new SelectedCity { City = Enums.CitiesEnum.Gothenburg };

        private readonly VehicleType _emergency = new VehicleType { Vehicle = Enums.VehiclesEnum.Emergency };
        private IConfigurationBuilder builder;
        private IConfigurationRoot _configuration;
        private ApplicationDbContext dbContext;
        private TaxCalculatorRepository calc;
        private DbContextOptions<ApplicationDbContext> _options;
        public UnitTests()
        {
            builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=TaxCalculatorApi")
                .Options;

            dbContext = new ApplicationDbContext(_options);
            calc = new TaxCalculatorRepository(dbContext);
        }

        [TestMethod]
        public void TaxCalculatorTest()
        {
            DateTime[] date = new DateTime[]
        {

                new DateTime(2013, 10, 1, 8, 15, 0),
                new DateTime(2013, 10, 1, 8, 30, 1),
                new DateTime(2013, 10, 1, 8, 45, 2),
                new DateTime(2013, 10, 1, 9, 20, 3),
                new DateTime(2013, 10, 1, 15, 32, 3),

        };

            var result = calc.GetTotalTax(_car, date, _selectedCity);

            Assert.AreEqual(39, result);
        }

        [TestMethod]
        public void TaxCalculatorForHoliday()
        {
            DateTime[] date = new DateTime[]
            {

                new DateTime(2013, 1, 1, 8, 15, 0),
                new DateTime(2013, 1, 1, 8, 30, 1),
                new DateTime(2013, 1, 1, 8, 45, 2),
                new DateTime(2013, 1, 1, 9, 15, 3),
             };


            var result = calc.GetTotalTax(_car, date, _selectedCity);

            Assert.AreEqual(0, result);
        }
    }
}
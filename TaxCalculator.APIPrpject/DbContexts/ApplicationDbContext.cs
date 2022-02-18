using Microsoft.EntityFrameworkCore;
using TaxCalculatorService.APIPrpject.Models;

namespace TaxCalculatorService.APIPrpject.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CongestionTax> TaxFees { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<City> Cities { get; set; }
   
    }
}

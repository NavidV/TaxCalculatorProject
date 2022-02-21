using Microsoft.EntityFrameworkCore;
using DataService.APIProject.Models;

namespace DataService.APIProject.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CongestionTax> TaxFees { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<SelectedCity> Cities { get; set; }
    }
}


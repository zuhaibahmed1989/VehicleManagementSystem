using Microsoft.EntityFrameworkCore;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.DataAccess
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }

        public DbSet<Car> Cars { get; internal set; }
    }
}
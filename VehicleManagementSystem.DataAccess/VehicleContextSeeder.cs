using Microsoft.EntityFrameworkCore;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.DataAccess
{
    public static class VehicleContextSeeder
    {
        public static void SeedData(this ModelBuilder builder)
        {
            var cars = CarDataSeedBuilder.GetCars();
            builder.Entity<Car>().HasData(cars);
        }
    }
}
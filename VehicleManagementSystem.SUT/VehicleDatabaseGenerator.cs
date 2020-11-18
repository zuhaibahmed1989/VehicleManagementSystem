using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleManagementSystem.DataAccess;

namespace VehicleManagementSystem.SUT
{
    public class VehicleDatabaseGenerator
    {
        public static async Task<VehicleContext> Initialize()
        {
            var builder = new DbContextOptionsBuilder<VehicleContext>();
            builder.UseInMemoryDatabase(databaseName: "VehicleInMemoryDb")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            var cars = CarDataSeedBuilder.GetCars();

            var context = new VehicleContext(builder.Options);
            await context.Cars.AddRangeAsync(cars);
            await context.SaveChangesAsync();
            return context;
        }
    }
}
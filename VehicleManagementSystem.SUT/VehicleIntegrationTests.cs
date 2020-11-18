using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehiceManagementSystem.Application.Services;
using VehiceManagementSystem.Domain.Core.Enums;
using VehicleManagementSystem.Application.Dtos;
using VehicleManagementSystem.Controllers;
using VehicleManagementSystem.DataAccess;
using VehicleManagementSystem.Domain.Core.Model.Vehicles;
using Xunit;

namespace VehicleManagementSystem.SUT
{
    public class VehicleIntegrationTests
    {
        [Fact]
        public async Task TryDataSeedingToInMemoryDatabaseAsync()
        {
            var context = await VehicleDatabaseGenerator.Initialize();

            Assert.Equal(5, await context.Cars.CountAsync());
            await context.DisposeAsync();
        }

        [Fact]
        public async Task AddCarToInMemoryDatabaseAsync()
        {
            var context = await VehicleDatabaseGenerator.Initialize();

            ICarRepository carRepository = new CarRepository(context);
            ICarService carService = new CarService(carRepository, context);

            CreateCarDto createCarDto = new CreateCarDto()
            {
                Make = "Audi",
                Model = "A8",
                Engine = "8cyl",
                Doors = 4,
                Wheels = 4,
                BodyType = CarBodyType.Sedan
            };

            await carService.CreateAsync(createCarDto);

            await context.SaveChangesAsync();

            Assert.True(await context
                .Cars
                .AnyAsync(car => car.Make == "Audi" &&
                    car.Model == "A8" &&
                    car.Engine == "8cyl" &&
                    car.Doors == 4 &&
                    car.Wheels == 4 &&
                    car.BodyType == CarBodyType.Sedan &&
                    car.VehicleType == VehicleType.Car));

            await context.DisposeAsync();
        }

        [Fact]
        public async Task AddCarViaController()
        {
            var context = await VehicleDatabaseGenerator.Initialize();

            ICarRepository carRepository = new CarRepository(context);
            ICarService carService = new CarService(carRepository, context);

            var controller = new CarsController(carService);

            CreateCarDto createCarDto = new CreateCarDto()
            {
                Make = "Audi",
                Model = "A8",
                Engine = "8cyl",
                Doors = 4,
                Wheels = 4,
                BodyType = CarBodyType.Sedan
            };

            var response = await controller.AddAsync(createCarDto);

            Assert.IsType<OkResult>(response);

            Assert.True(await context
                .Cars
                .AnyAsync(car => car.Make == "Audi" &&
                    car.Model == "A8" &&
                    car.Engine == "8cyl" &&
                    car.Doors == 4 &&
                    car.Wheels == 4 &&
                    car.BodyType == CarBodyType.Sedan &&
                    car.VehicleType == VehicleType.Car));

            await context.DisposeAsync();
        }
    }
}
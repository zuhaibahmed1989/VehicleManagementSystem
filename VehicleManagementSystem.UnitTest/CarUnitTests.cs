using System;
using VehiceManagementSystem.Domain.Core.Enums;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;
using Xunit;

namespace VehicleManagementSystem.UnitTest
{
    public class CarUnitTests
    {
        [Fact]
        //Try to add Toyota Camry and verify that it has 6 cylinder engine, 4 wheels, 4 doors and sedan body.
        public void BDDScenario_1_1_1()
        {
            string make = "Toyota";
            string model = "Camry";
            string engine = "6 cylinder Petrol Aspirated 3.5L";
            int doors = 4;
            int wheels = 4;

            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();

            CreateCarCommand createCarCommand = new CreateCarCommand(make,
                model,
                engine,
                doors,
                wheels,
                CarBodyType.Sedan);

            Car car = factory.Create(createCarCommand);

            Assert.NotNull(car);
            Assert.Equal(make, car.Make);
            Assert.Equal(model, car.Model);
            Assert.Equal(engine, car.Engine);
            Assert.Equal(doors, car.Doors);
            Assert.Equal(wheels, car.Wheels);
            Assert.Equal(CarBodyType.Sedan, car.BodyType);
        }

        [Fact]
        //try to add a car Honda Civic and verify that it has 4 cylinder engine, 4 wheels, 5 doors and hatchback body.
        public void BDDScenario_1_2_1()
        {
            string make = "Honda";
            string model = "Civic";
            string engine = "4 cylinder Petrol Aspirated 1.8L";
            int doors = 5;
            int wheels = 4;

            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();

            CreateCarCommand createCarCommand = new CreateCarCommand(make,
                model,
                engine,
                doors,
                wheels,
                CarBodyType.Hatchback);

            Car car = factory.Create(createCarCommand);

            Assert.NotNull(car);
            Assert.Equal(make, car.Make);
            Assert.Equal(model, car.Model);
            Assert.Equal(engine, car.Engine);
            Assert.Equal(doors, car.Doors);
            Assert.Equal(wheels, car.Wheels);
            Assert.Equal(CarBodyType.Hatchback, car.BodyType);
        }

        [Fact]
        public void BDDScenario_1_2_2_HondaCivicHavingZeroNumOfDoorsShouldFail()
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make: "Honda",
                model: "Civic",
                engine: "4 cylinder Petrol Aspirated 1.8L",
                doors: 0,
                wheels: 4,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Doors).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Fact]
        public void BDDScenario_1_2_3_HondaCivicHavingTwentyNumOfDoorsShouldFail()
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make: "Honda",
                model: "Civic",
                engine: "4 cylinder Petrol Aspirated 1.8L",
                doors: 20,// easy to mistype 20 instead of 2
                wheels: 4,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Doors).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Fact]
        public void BDDScenario_1_2_4_HondaCivicHavingZeroNumOfWheelsShouldFail()
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make: "Honda",
                model: "Civic",
                engine: "4 cylinder Petrol Aspirated 1.8L",
                doors: 5,
                wheels: 0,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Wheels).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Fact]
        public void BDDScenario_1_2_5_HondaCivicHavingTwentyNumOfWheelsShouldFail()
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make: "Honda",
                model: "Civic",
                engine: "4 cylinder Petrol Aspirated 1.8L",
                doors: 5,
                wheels: 20,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Wheels).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Fact]
        // Demo for future extension: Add a Kawasaki boat and verify that it is a boat.
        public void BDDScenario_2_1_1()
        {
            string make = "Kawasaki";
            string model = "Jet Ski SX-R";
            string engine = "6-cylinder, 4-stroke";
            int doors = 4;
            int wheels = 4;

            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();

            CreateCarCommand createCarCommand = new CreateCarCommand(make,
                model,
                engine,
                doors,
                wheels,
                CarBodyType.Sedan);

            Car car = factory.Create(createCarCommand);

            Assert.NotNull(car);
            Assert.Equal(make, car.Make);
            Assert.Equal(model, car.Model);
            Assert.Equal(engine, car.Engine);
            Assert.Equal(doors, car.Doors);
            Assert.Equal(wheels, car.Wheels);
            Assert.Equal(CarBodyType.Sedan, car.BodyType);
        }
    }
}
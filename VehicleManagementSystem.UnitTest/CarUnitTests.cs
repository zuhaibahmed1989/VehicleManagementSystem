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

        [Theory]
        [InlineData("Honda", "Civic", "4 cylinder Petrol Aspirated 1.8L", 0, 4)]//zero num of doors is incorrect for a car
        [InlineData("Honda", "Civic", "4 cylinder Petrol Aspirated 1.8L", 20, 4)]//Twenty num of doors is incorrect for a car
        public void BDDScenario_1_2_2_HondaCivicHavingInvalidNumOfDoorsShouldFail(string make,
                string model,
                string engine,
                int doors,
                int wheels)
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make,
                model,
                engine,
                doors,
                wheels,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Doors).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Theory]
        [InlineData("Honda", "Civic", "4 cylinder Petrol Aspirated 1.8L", 5, 0)]//zero num of wheels is incorrect for a car
        [InlineData("Honda", "Civic", "4 cylinder Petrol Aspirated 1.8L", 5, 20)]//Twenty num of wheels is incorrect for a car
        public void BDDScenario_1_2_4_HondaCivicHavingInvalidNumOfWheelsShouldFail(string make,
                string model,
                string engine,
                int doors,
                int wheels)
        {
            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            CreateCarCommand createCarCommand = new CreateCarCommand(make,
                model,
                engine,
                doors,
                wheels,
                CarBodyType.Hatchback);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(createCarCommand));
            Assert.Equal(nameof(Car.Wheels).ToLowerInvariant(), exception.ParamName.ToLowerInvariant());
        }

        [Fact]
        // Demo for future extension: Add a Kawasaki boat and verify that it is a boat.
        public void BDDScenario_2_1_1()
        {
            //string make = "Kawasaki";
            //string model = "Jet Ski SX-R";
            //string engine = "6-cylinder, 4-stroke";

            //IVehicleFactory<Boat, CreateBoatCommand> factory = new BoatFactory();

            //CreateBoatCommand createBoatCommand = new CreateBoatCommand(make,
            //    model,
            //    engine,
            //    CarBodyType.Sedan);

            //Boat boat = factory.Create(createBoatCommand);

            //Assert.NotNull(boat);
            //Assert.Equal(make, boat.Make);
            //Assert.Equal(model, boat.Model);
            //Assert.Equal(engine, boat.Engine);
        }
    }
}
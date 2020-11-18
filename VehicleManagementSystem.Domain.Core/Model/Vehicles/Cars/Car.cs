using System;
using VehiceManagementSystem.Domain.Core.Enums;
using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    public class Car : IVehicle
    {
        public Guid Id { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Engine { get; private set; }
        public int Doors { get; private set; }
        public int Wheels { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public CarBodyType BodyType { get; private set; }

        protected Car()
        {
            Id = Guid.NewGuid();
            VehicleType = VehicleType.Car;
        }

        private Car(string make,
            string model,
            string engine,
            int doors,
            int wheels,
            CarBodyType bodyType) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Engine = engine;
            this.Doors = doors;
            this.Wheels = wheels;
            this.BodyType = bodyType;
        }

        public static Car Create(CreateCarCommand command, ICarValidator validator)
        {
            var car = new Car(command.Make,
                command.Model,
                command.Engine,
                command.Doors,
                command.Wheels,
                command.BodyType);

            validator.Validate(car);

            return car;
        }
    }
}
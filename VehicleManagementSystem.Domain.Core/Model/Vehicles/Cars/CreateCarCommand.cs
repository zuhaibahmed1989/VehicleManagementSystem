using VehiceManagementSystem.Domain.Core.Enums;

namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    public class CreateCarCommand : ICreateVehicleCommand
    {
        public string Make { get; }
        public string Model { get; }
        public string Engine { get; }
        public int Doors { get; }
        public int Wheels { get; }
        public CarBodyType BodyType { get; }

        public CreateCarCommand(string make,
            string model,
            string engine,
            int doors,
            int wheels,
            CarBodyType bodyType)
        {
            this.Make = make;
            this.Model = model;
            this.Engine = engine;
            this.Doors = doors;
            this.Wheels = wheels;
            this.BodyType = bodyType;
        }
    }
}
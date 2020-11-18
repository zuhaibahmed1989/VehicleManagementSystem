using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    public class CarFactory : IVehicleFactory<Car, CreateCarCommand>
    {
        public Car Create(CreateCarCommand command)
        {
            var validator = new CarValidator();

            var car = Car.Create(command, validator);

            return car;
        }
    }
}
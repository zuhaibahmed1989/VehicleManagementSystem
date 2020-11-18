using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    /// <summary>
    /// Vehicle factory is responsible for creating Different types of vehicles.
    /// TVehicle is type of Vehicle(Car, Boat, Motorcycle).
    /// TCreateCommand is a type of Create Command for vehicle such as CreateCarCommand, CreateBoatCommand.
    /// </summary>
    public interface IVehicleFactory<TVehicle, TCreateCommand>
        where TVehicle : IVehicle
        where TCreateCommand : ICreateVehicleCommand
    {
        TVehicle Create(TCreateCommand command);
    }
}
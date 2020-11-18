namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    public interface ICreateVehicleCommand
    {
        string Make { get; }
        string Model { get; }
    }
}
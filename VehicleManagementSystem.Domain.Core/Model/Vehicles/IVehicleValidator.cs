using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.Domain.Core.Model.Vehicles
{
    public interface IVehicleValidator<TVehicle>
        where TVehicle : IVehicle
    {
        void Validate(TVehicle vehicle);
    }
}
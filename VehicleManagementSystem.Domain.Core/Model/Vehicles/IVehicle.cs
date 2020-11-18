using System;
using VehiceManagementSystem.Domain.Core.Enums;

namespace VehiceManagementSystem.Domain.Core.Model.Vehicles
{
    public interface IVehicle
    {
        Guid Id { get; }
        string Make { get; }
        string Model { get; }
        VehicleType VehicleType { get; }
    }
}
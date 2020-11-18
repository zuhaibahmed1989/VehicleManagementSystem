using System;
using VehiceManagementSystem.Domain.Core;
using VehiceManagementSystem.Domain.Core.Enums;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.Domain.Core.Model.Vehicles
{
    public class CarValidator : ICarValidator
    {
        public void Validate(Car car)
        {
            Check.IsNullOrWhiteSpace(nameof(Car.Make), car.Make);
            Check.IsNullOrWhiteSpace(nameof(Car.Model), car.Model);
            Check.IsNullOrWhiteSpace(nameof(Car.Engine), car.Engine);
            if (car.Doors < 1 || car.Doors > 19)// to avoid human error
                throw new ArgumentOutOfRangeException(nameof(Car.Doors), $"Specified number of doors for {nameof(Car)} is invalid." +
                    " Please provide a valid range between 1 and 19.");

            if (car.Wheels < 1 || car.Wheels > 19)// to avoid human error
                throw new ArgumentOutOfRangeException(nameof(Car.Wheels), $"Specified number of wheels for {nameof(Car)} is invalid." +
                    " Please provide a valid range between 1 and 19.");

            if (!Enum.IsDefined(typeof(CarBodyType), car.BodyType))
                throw new ArgumentOutOfRangeException($"Specified value for {nameof(CarBodyType)} is not defined.");
        }
    }
}
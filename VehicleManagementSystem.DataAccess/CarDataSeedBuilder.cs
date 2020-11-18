using System.Collections.Generic;
using VehiceManagementSystem.Domain.Core.Enums;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.DataAccess
{
    public class CarDataSeedBuilder
    {
        public static IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>()
            {
                new CarFactory()
                .Create(new CreateCarCommand(make: "Toyota",
                    model: "Corolla",
                    engine: "4cyl",
                    doors: 4,
                    wheels: 4,
                    CarBodyType.Sedan)),

                new CarFactory()
                .Create(new CreateCarCommand(make: "Toyota",
                    model: "Yaris",
                    engine: "4cyl",
                    doors: 3,
                    wheels: 4,
                    CarBodyType.Hatchback)),

                new CarFactory()
                .Create(new CreateCarCommand(make: "Ford",
                    model: "Falcon",
                    engine: "6cyl",
                    doors: 4,
                    wheels: 4,
                    CarBodyType.Sedan)),

                new CarFactory()
                .Create(new CreateCarCommand(make: "Holden",
                    model: "Commodore",
                    engine: "6cyl",
                    doors: 4,
                    wheels: 4,
                    CarBodyType.Sedan)),

                new CarFactory()
                .Create(new CreateCarCommand(make: "Nissan",
                    model: "Leaf",
                    engine: "cylinder Electric L",
                    doors: 5,
                    wheels: 4,
                    CarBodyType.Hatchback)),
            };

            return cars;
        }
    }
}
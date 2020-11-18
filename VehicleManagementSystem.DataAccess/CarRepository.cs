using System;
using System.Threading.Tasks;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;
using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.DataAccess
{
    public class CarRepository : ICarRepository
    {
        private readonly VehicleContext _context;

        public CarRepository(VehicleContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            await _context.Cars.AddAsync(car);
        }
    }
}
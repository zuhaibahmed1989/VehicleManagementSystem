using System.Threading.Tasks;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;
using VehicleManagementSystem.Application.Dtos;
using VehicleManagementSystem.DataAccess;
using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehiceManagementSystem.Application.Services
{

    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly VehicleContext _context;

        public CarService(ICarRepository carRepository, VehicleContext context)
        {
            this._carRepository = carRepository;
            this._context = context;
        }

        public async Task CreateAsync(CreateCarDto createCarDto)
        {
            var createCarCommand = new CreateCarCommand(createCarDto.Make,
                createCarDto.Model,
                createCarDto.Engine,
                createCarDto.Doors,
                createCarDto.Wheels,
                createCarDto.BodyType);

            IVehicleFactory<Car, CreateCarCommand> factory = new CarFactory();
            Car car = factory.Create(createCarCommand);

            await _carRepository.AddAsync(car);
            await _context.SaveChangesAsync();
        }
    }
}
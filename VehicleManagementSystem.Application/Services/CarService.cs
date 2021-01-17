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
        private readonly IVehicleFactory<Car, CreateCarCommand> _factory;

        public CarService(ICarRepository carRepository, 
            VehicleContext context, 
            IVehicleFactory<Car, CreateCarCommand> carFactory)
        {
            this._carRepository = carRepository;
            this._context = context;
            this._factory = carFactory;
        }

        public async Task CreateAsync(CreateCarDto createCarDto)
        {
            var createCarCommand = new CreateCarCommand(createCarDto.Make,
                createCarDto.Model,
                createCarDto.Engine,
                createCarDto.Doors,
                createCarDto.Wheels,
                createCarDto.BodyType);

            Car car = _factory.Create(createCarCommand);

            await _carRepository.AddAsync(car);
            await _context.SaveChangesAsync();
        }
    }
}
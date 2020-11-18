using System.Threading.Tasks;
using VehicleManagementSystem.Application.Dtos;

namespace VehiceManagementSystem.Application.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarDto createCarDto);
    }
}
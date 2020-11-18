using System.Threading.Tasks;
using VehiceManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem.Domain.Core.Model.Vehicles
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
    }
}
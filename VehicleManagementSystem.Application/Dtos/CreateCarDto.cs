using VehiceManagementSystem.Domain.Core.Enums;

namespace VehicleManagementSystem.Application.Dtos
{
    /// <summary>
    /// Create Car Data transfer object
    /// </summary>
    public class CreateCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public CarBodyType BodyType { get; set; }
    }
}
namespace VehicleManagementSystem.Controllers
{
    public class MakeViewModel
    {
        public string Name { get; set; }
        public string[] Models { get; set; }

        public MakeViewModel(string name, string[] models)
        {
            this.Name = name;
            this.Models = models;
        }
    }
}
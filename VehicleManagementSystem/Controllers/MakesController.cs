using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VehicleManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetMakes()
        {
            return Ok(new List<MakeViewModel>() 
            { 
                new MakeViewModel("Toyota", new string[] { "Corolla", "Camry", "4Runner"}),
                new MakeViewModel("Honda", new string[] {"Accord", "Civic", "CR-V", "CR-X", "CR-Z" }),
                new MakeViewModel("Holden", new string[] { "Barina", "Astra", "Commodore", "Captiva", "Adventra" }),
                new MakeViewModel("Nissan", new string[] { "Pulsar", "Maxima", "GT-R"})
            });
        }
    }
}
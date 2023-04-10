using Microsoft.AspNetCore.Mvc;

namespace Yeremenko_HW1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static readonly string[] Models = new[]
        {
        "Toyota", "Audi", "BMW", "Ford", "Volkswagen", "Mercedes", "Fiat", "Kia"
        };

        private static readonly string[] Transmissions = new[]
        {
        "Mechanical", "Automatic"
        };

        private static readonly string[] TypesOfFuel = new[]
        {
        "Petrol", "Diesel", "Gas"
        };

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCarList")]
        public IEnumerable<Car> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new Car
            {
                Model = Models[Random.Shared.Next(Models.Length)],
                YearOfIssue = Random.Shared.Next(1990,DateTime.Now.Year),
                Transmission = Transmissions[Random.Shared.Next(Transmissions.Length)],
                TypeOfFuel = TypesOfFuel[Random.Shared.Next(TypesOfFuel.Length)],
                Mileage = Random.Shared.Next(0, 1000000)
            })
            .ToArray();
        }
    }
}
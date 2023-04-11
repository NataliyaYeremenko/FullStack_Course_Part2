using Microsoft.AspNetCore.Mvc;

namespace Yeremenko_HW1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsListController : ControllerBase
    {
        private static readonly string[] Models = new[]
        {
        "Toyota", "Audi", "Volkswagen", "BMW", "Mercedes", "Kia", "Opel", "Nissan", "Reno", "Ford", "Porsche"
        };
        private static readonly string[] FuelTypes = new[]
        {
        "Diesel", "Petrol", "Electric", "Ethanol", "Hybrid"
        };
        private static readonly string[] Transmissions = new[]
        {
        "Automatic", "Mechanical"
        };
        private static readonly string[] Colors = new[]
        {
        "Black", "White", "Red", "Blue", "Yellow", "Green", "N/A"
        };

        public static IEnumerable<Car> carsList = Enumerable.Range(1, 10).Select(index => new Car
        {
            Model = Models[Random.Shared.Next(Models.Length)],
            YearOfIssue = Random.Shared.Next(1990, DateTime.Now.Year),
            FuelType = FuelTypes[Random.Shared.Next(FuelTypes.Length)],
            Transmission = Transmissions[Random.Shared.Next(Transmissions.Length)],
            Mileage = Random.Shared.Next(0, 1000000),
            Color = Models[Random.Shared.Next(Colors.Length)],
        })
            .ToArray();

        private readonly ILogger<CarsListController> _logger;

        public CarsListController(ILogger<CarsListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFullCarsList")]
        public IEnumerable<Car> Get() => carsList;

    }
}

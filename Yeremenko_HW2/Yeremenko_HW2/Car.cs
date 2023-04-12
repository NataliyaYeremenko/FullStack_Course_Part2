using System.Reflection;
using System.Text;

namespace Yeremenko_HW2
{
    public class Car
    {
        private static int _carCount;
        public int CarId { get; private set; }
        public string Model { get; set; }
        public int YearOfIssue { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }

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
        "Black", "White", "Red", "Blue", "Yellow", "Green"
        };

        public static List<Car> carsList = new List<Car>();

        public static void GenerateRandomCarsList(int size)
        {
            carsList = Enumerable.Range(1, size).Select(index => new Car
            {
                CarId = ++_carCount,
                Model = Models[Random.Shared.Next(Models.Length)],
                YearOfIssue = Random.Shared.Next(1990, DateTime.Now.Year),
                FuelType = FuelTypes[Random.Shared.Next(FuelTypes.Length)],
                Transmission = Transmissions[Random.Shared.Next(Transmissions.Length)],
                Mileage = Random.Shared.Next(0, 1000000),
                Color = Colors[Random.Shared.Next(Colors.Length)]
            })
            .ToList();
        }
        public Car() { }
        public Car(string model, int yearOfIssue, string fuelType = "N/A", string transmission = "N/A", int mileage = 0, string color = "N/A")
        {
            CarId = ++_carCount;
            Model = model;
            YearOfIssue = yearOfIssue;
            FuelType = fuelType;
            Transmission = transmission;
            Mileage = mileage;
            Color = color;
        }

        public string PrintInfo()
        {
            return ($"ID={CarId}\tModel: {Model}\n\tYear of issue: {YearOfIssue}\n\tFuelType: {FuelType}\n\t" +
                $"Transmission: {Transmission}\n\tMileage: {Mileage}\n\tColor: {Color}\n");
        }
        public static string GetCarsListInfo()
        {
            var sb = new StringBuilder();
            foreach (var car in carsList) { sb.AppendLine(car.PrintInfo()); }
            return sb.ToString();
        }
    }
}

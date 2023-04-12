using System.Text;

namespace Yeremenko_HW2
{
    public class ManagementCars : IManagementCars
    {
        public string GetCarModel(params int[] id)
        {
            if (id.Length == 1) { return $"CarID={id[0]}\tModel: {Car.carsList.ElementAt(id[0] - 1).Model}\n"; }
            else
            {
                var sb = new StringBuilder();
                sb.Append("All cars models: ");
                var modelList = Car.carsList.Select(car => car.Model).Distinct().Order().ToList();
                for (int i = 0; i < modelList.Count; i++)
                {
                    sb.Append(modelList[i]);
                    if (i < modelList.Count - 1) { sb.Append(", "); }
                    else { sb.AppendLine(); }
                }
                return sb.ToString();
            }
        }
        public string GetCarAge(params int[] id)
        {
            if (id.Length == 1) { return $"CarID={id[0]}\tAge: {DateTime.Now.Year - Car.carsList.ElementAt(id[0] - 1).YearOfIssue}\n"; }
            else
            {
                var sb = new StringBuilder();
                sb.Append("All cars ages: ");
                var ageList = Car.carsList.Select(car => DateTime.Now.Year - car.YearOfIssue).Distinct().Order().ToList();
                for (int i = 0; i < ageList.Count; i++)
                {
                    sb.Append(ageList[i]);
                    if (i < ageList.Count - 1) { sb.Append(", "); }
                    else { sb.AppendLine(); }
                }
                return sb.ToString();
            }
        }
        public string GetCarEngine(params int[] id)
        {
            if (id.Length == 1) { return $"CarID={id[0]}\tEngine: {Car.carsList.ElementAt(id[0] - 1).FuelType}\n"; }
            else
            {
                var sb = new StringBuilder();
                sb.Append("All cars engine types: ");
                var engineList = Car.carsList.Select(car => car.FuelType).Distinct().Order().ToList();
                for (int i = 0; i < engineList.Count; i++)
                {
                    sb.Append(engineList[i]);
                    if (i < engineList.Count - 1) { sb.Append(", "); }
                    else { sb.AppendLine(); }
                }
                return sb.ToString();
            }
        }
    }
}

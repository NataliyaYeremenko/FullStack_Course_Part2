using Microsoft.AspNetCore.Mvc;

 namespace Yeremenko_HW1.Controllers
 {
     [Route("[controller]")]
     [ApiController]
     public class CarController : ControllerBase
     {

         [HttpGet(Name = "GetCarsByIndex")]
         public Car Get(int index) => CarsListController.carsList.ElementAt(index);

     }
 }


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizza.Model;

namespace pizza.Controllers
{
    [Route("api/Pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public PizzaController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        private readonly IEnumerable<PizzaInfo> GetData = new[]
         {
            new PizzaInfo {Id=1, PizzaName = "The Mighty Meatball", Ingredients = "Meatballs and cheese", Cost = 40, InStock = "yes"},
            new PizzaInfo {Id=2,  PizzaName = "Crab Apple", Ingredients = "Dungeness crab and apples", Cost = 35, InStock = "no"},
            new PizzaInfo {Id=3,  PizzaName = "Forest Floor", Ingredients = "Mushrooms, rutabagas, and walnuts", Cost = 20, InStock = "yes"},
            new PizzaInfo {Id=4,  PizzaName = "Don't At Me", Ingredients = "Pineapple, Canadian bacon, jalapeños", Cost = 25, InStock = "yes"},
            new PizzaInfo {Id=5,  PizzaName = "Vanilla", Ingredients = "Sausage and pepperoni", Cost = 15, InStock = "no"},
            new PizzaInfo {Id=6,  PizzaName = "Spice Coming At Ya", Ingredients = "Peppers, chili sauce, spicy andouille", Cost = 50, InStock = "yes"}
         };

        [HttpGet]
        [Route("GetAllPizzas")]
        public IEnumerable<PizzaInfo> GetAllPizzas()
        {
            var result = GetData;

            return result;
        }

        [HttpGet]
        [Route("GetPizzaById/{id}")]
        public IEnumerable<PizzaInfo> GetPizzaById(int id)
        {
            //testing static method
            Delete.PrintName();

            int? i = null;

            var result = GetData.ToList().Where(x => x.Id == id);

            return result;
        }
    }

    public class PizzaInfo
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }

        public int Cost { get; set; }

        public string Ingredients { get; set; }

        public string InStock { get; set; }
    }
}

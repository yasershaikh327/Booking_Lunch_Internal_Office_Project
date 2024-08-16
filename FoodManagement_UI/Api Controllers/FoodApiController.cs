using FoodInventoryManagement.Models.UIModels;
using FoodInventoryManagement.Repository;
using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodManagement_UI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class FoodApiController : ControllerBase
    {
        private readonly ILogger<FoodApiController> _logger;
        private readonly IFoodRepository _foodrepository;

        public FoodApiController(ILogger<FoodApiController> logger, IFoodRepository foodrepository)
        {
            _logger = logger;
            _foodrepository = foodrepository;
        }

        //Fetch Food 
        [HttpGet]
        public IEnumerable<Food> Gets(string type)
        {
            return _foodrepository.GetFoodByType(type);
        }

        [HttpGet]
        public IEnumerable<Food> AdminFetchFood(string Type, string Day, int Week)
        {
            return _foodrepository.GetFoodByTypeAndTime(Type,Day,Week);
        }


        //Remove Food Item
        [HttpDelete]
        public void RemoveFood(int ID)
        {
            _foodrepository.RemoveFoodItem(ID);
       }


        //Update Food
        [HttpPatch]
        public void UpdateFood(int ID, string foodItemName)
        {
            _foodrepository.UpdateFoodItem(ID, foodItemName);
        }


        //Add Food
        [HttpPost]
        public void AddFood(Food food)
        {
            _foodrepository.AddFoodItem(food);
        }
    }
}

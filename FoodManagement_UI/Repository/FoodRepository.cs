using FoodInventoryManagement.DataAccess;
using FoodInventoryManagement.Models.Dtos.Mappers;
using FoodInventoryManagement.Models.UIModels;
using FoodManagement_UI.Helpers;
using FoodManagement_UI.Models.Dtos.Mappers;
using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Repository;
using System.Globalization;

namespace FoodInventoryManagement.Repository
{

    
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodManagementDB _dbContext;
        private readonly IFoodMapper _foodMapper;
        private readonly IFoodDtoMapper _foodDTOMapper;

        private readonly IHelper _helper;

        public FoodRepository(FoodManagementDB dbContext, IFoodMapper foodMapper, IFoodDtoMapper foodDTOMapper,IHelper helper)
        {
            _dbContext = dbContext;
            _foodMapper = foodMapper;
            _foodDTOMapper = foodDTOMapper;
            _helper = helper;
        }

        public List<Food> GetFoodByTypeAndTime(string Type, string Day, int Week)
        {
            var foodList = _dbContext.FoodDto.Where(x => x.Week == Week && x.Day == Day && x.Type == Type).ToList();
            return _foodMapper.Map(foodList);
        }

        public List<Food> GetFoodByType(string Type)
        {
            string Day  = DateTime.Now.DayOfWeek.ToString();
            var foodList = _dbContext.FoodDto.Where(x => x.Week == _helper.GetIso8601WeekOfYear() && x.Day == Day && x.Type == Type).ToList();
            return _foodMapper.Map(foodList);
        }




        //CRUD Operation:
        //Remove Food
        public bool RemoveFoodItem(int ID)
        {
            var foodItem = _dbContext.FoodDto.Find(ID);
            if (foodItem != null)
            {
                _dbContext.FoodDto.Remove(foodItem);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }


        //Update Food Item
        public bool UpdateFoodItem(int ID, string foodItemName)
        {
            var foodItem = _dbContext.FoodDto.Find(ID);
            if (foodItem != null)
            {
                foodItem.Name = foodItemName;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        //Add Food
        public bool AddFoodItem(Food food)
        {
            food.Week = (food.Week / 5 > 1) ? 1 : food.Week;
            var foodItem = _foodDTOMapper.Map(food);
            {
                _dbContext.FoodDto.Add(foodItem);
                _dbContext.SaveChanges();
                return true;
            }
        }
    }
}

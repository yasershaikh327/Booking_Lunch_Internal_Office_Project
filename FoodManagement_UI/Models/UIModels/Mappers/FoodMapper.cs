using FoodInventoryManagement.Models.UIModels;
using FoodManagement_UI.Models.UIModels;

namespace FoodInventoryManagement.Models.Dtos.Mappers
{
    public interface IFoodMapper
    {
        List<Food> Map(List<FoodDto> foodDto);
    }
    public class FoodMapper : IFoodMapper
    {
        public List<Food> Map(List<FoodDto> foodDto)
        {
            var food = new List<Food>();

            foreach (var dto in foodDto)
            {
                var foodItem = new Food
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Type = dto.Type,
                    Week = dto.Week,
                    Day = dto.Day,
                };

                food.Add(foodItem);
            }

            return food;
        }
    }
}

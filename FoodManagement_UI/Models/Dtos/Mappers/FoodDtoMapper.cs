using FoodInventoryManagement.Models.UIModels;

namespace FoodInventoryManagement.Models.Dtos.Mappers
{
    public interface IFoodDtoMapper
    {
        FoodDto Map(Food food);
    }
    public class FoodDtoMapper : IFoodDtoMapper
    {
        public FoodDto Map(Food food)
        {
            var foodDto = new FoodDto
            {
                Day = food.Day,
                Week = food.Week,
                Type = food.Type,
                Id = food.Id,
                Name = food.Name,
            };

            return foodDto;
        }
    }
}

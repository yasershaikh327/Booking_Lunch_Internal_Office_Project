using FoodInventoryManagement.Models.UIModels;
using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Repository
{
    public interface IFoodRepository
    {
        public List<Food> GetFoodByTypeAndTime(string Type,string Day,int Week);
        public List<Food> GetFoodByType(string Type);
        public bool RemoveFoodItem(int ID);
        public bool UpdateFoodItem(int ID, string foodItem);
        public bool AddFoodItem(Food food);
    }

}

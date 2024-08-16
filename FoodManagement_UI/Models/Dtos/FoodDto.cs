namespace FoodInventoryManagement.Models.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Day { get; set; }
        public int Week { get; set; }
    }
    public class FoodDtos
    {
        public FoodDtos()
        {
            dtos = new List<FoodDto>();
        }
        List<FoodDto> dtos;
    }
}

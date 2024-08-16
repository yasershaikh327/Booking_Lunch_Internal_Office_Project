using FoodInventoryManagement.Models.Dtos;
using FoodInventoryManagement.Models.Dtos.Mappers;
using FoodInventoryManagement.Models.UIModels;
using FoodInventoryManagement.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FoodInventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class HomeController : ControllerBase
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;


        public HomeController(ILogger<HomeController> logger,IRepository repository)
        {
            _logger = logger;
            _repository = repository;   
        }

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _repository.GetFood();
        }

    }
}
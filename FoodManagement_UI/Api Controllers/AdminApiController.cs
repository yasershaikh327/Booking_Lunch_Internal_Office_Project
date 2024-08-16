using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FoodManagement_UI.Api_Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class AdminApiController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AdminApiController(IEmployeeRepository employeeRepository) { 
            _employeeRepository = employeeRepository;
        }


        //Fetch Feedback
        [HttpGet]
        public IEnumerable<Feedback> FetchFeedback(string Data)
        {
            return _employeeRepository.DisplayFeedback();
        }


        //Fetch Bookings
        [HttpGet]
        public IEnumerable<Book> FetchBookings(string Data)
        {
            return _employeeRepository.FetchBookings();
        }

        //Fetch Employees
        [HttpGet]
        public IEnumerable<Registration> FetchEmployee(string Data)
        {
            return _employeeRepository.GetAllEmployees();
        }


        //Remove Employee
        [HttpDelete]
        public void RemoveEmployee(int ID)
        {
            _employeeRepository.RemoveRegistration(ID);
        }
    }
}


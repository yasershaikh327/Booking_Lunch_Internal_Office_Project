using Microsoft.AspNetCore.Mvc;
namespace FoodManagement_UI.Controllers
{
    
    public class HomeController : Controller
    {
        //HomePage
        public IActionResult Index()
        {   
             return View();
        }

        //Feedback
        public ActionResult Feedback()
        {
            return View();
        }

        //Show Menu Items
        public ActionResult ShowFoodItems()
        {
            return View();
        }

        //Login Page
        public IActionResult Login()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace FoodManagement_UI.Controllers
{
    public class AdminController : Controller
    {
        //Manage Food
        public IActionResult ManageFood()
        {
            return View();
        }


        //Remove Registered User
        public IActionResult RemoveUser()
        {
            return View();
        }


    }
}

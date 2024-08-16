using Microsoft.AspNetCore.Mvc;

namespace FoodManagement_UI.Controllers
{
    public class ErrorController : Controller
    {

        //Model State Invalid
        public IActionResult ModelStateInvalid()
        {
            return View();  
        }

        //Method State Invalid
        public IActionResult MethodStateInvalid()
        {
            return View();
        }

        //Page Not Found
        public IActionResult PageNotFound()
        {
            return View();
        }
        
        //Serve Error
        public IActionResult ServerError()
        {
            return View();
        }

        //Moved Permanently
        public IActionResult MovedPermanently()
        {
            return View();
        }

        //UnAuthrized
        public IActionResult UnAuthorized()
        {
            return View();
        }

        //Forbidden
        public IActionResult Forbidden()
        {
            return View();
        }

        //NotImplemented
        public IActionResult NotImplemented()
        {
            return View();
        }
    }
}

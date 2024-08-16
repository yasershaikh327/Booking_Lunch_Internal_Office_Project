namespace FoodManagement_UI.Models.UIModels
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public enum LoginStatus 
    { 
        Admin,
        Error
    }

}


namespace FoodManagement_UI.Models.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtos
    {
        LoginDtos loginDtos { get; set; }
        public LoginDtos()
        {
            loginDtos = new LoginDtos();    
        }

    }
}

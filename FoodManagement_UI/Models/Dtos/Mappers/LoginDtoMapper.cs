using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface ILoginDtoMapper
    {
        LoginDto Map(Login login);
    }
    public class LoginDtoMapper : ILoginDtoMapper
    {
        public LoginDto Map(Login login)
        {
            var loginDto = new LoginDto();  
            loginDto.Email = login.Email;   
            loginDto.Password = login.Password;
            return loginDto;
        }
    }
}

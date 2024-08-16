
using FoodManagement_UI.Models.Dtos;

namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface ILoginMapper
    {
        Login Map(LoginDto loginDto);
    }
    public class LoginMapper : ILoginMapper
    {
        public Login Map(LoginDto loginDto)
        {
            var Login = new Login();
            Login.Email = loginDto.Email;   
            Login.Password = loginDto.Password; 
            return Login;
        }
    }
}

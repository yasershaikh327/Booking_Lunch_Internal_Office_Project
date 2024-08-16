using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface IVerfiyEmailDtoMapper
    {
        VerifyEmailDto Map(VerifyEmail verifyEmail);
    }
    public class VerfiyEmailDtoMapper : IVerfiyEmailDtoMapper
    {
        public VerifyEmailDto Map(VerifyEmail verifyEmail)
        {
            var VerifyDto = new VerifyEmailDto()
            {
                Email = verifyEmail.Email,
            };
            return VerifyDto;
        }
    }
}

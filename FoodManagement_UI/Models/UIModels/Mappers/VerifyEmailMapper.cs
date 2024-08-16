using FoodManagement_UI.Models.Dtos;

namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface IVerifyEmailMapper
    {
        VerifyEmail Map(VerifyEmailDto verifyEmailDto);
    }
    public class VerifyEmailMapper : IVerifyEmailMapper
    {
        public VerifyEmail Map(VerifyEmailDto verifyEmailDto)
        {
            var Verify = new VerifyEmail();
            Verify.Email = verifyEmailDto.Email;
            return Verify;
        }
    }
}

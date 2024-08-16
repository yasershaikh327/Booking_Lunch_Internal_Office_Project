using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface IUpdatepasswordDtoMapper
    {
        UpdatepasswordDto Map(Updatepassword updatepassword);
    }
    public class UpdatepasswordDtoMapper : IUpdatepasswordDtoMapper
    {
        public UpdatepasswordDto Map(Updatepassword updatepassword)
        {
            var updatepasswordDto = new UpdatepasswordDto();
            updatepasswordDto.Id = updatepassword.Id;
            updatepasswordDto.Password = updatepassword.Password;
            updatepasswordDto.oldPassword = updatepassword.oldPassword;
            return updatepasswordDto;
        }
    }
}

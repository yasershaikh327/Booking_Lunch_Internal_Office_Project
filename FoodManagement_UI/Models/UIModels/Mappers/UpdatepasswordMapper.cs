namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface IUpdatepasswordMapper
    {
        Updatepassword Map(UpdatepasswordDto updatepasswordDto);
    }
    public class UpdatepasswordMapper : IUpdatepasswordMapper
    {
        public Updatepassword Map(UpdatepasswordDto updatepasswordDto)
        {
           var updatepassword = new Updatepassword();
            updatepassword.Id = updatepasswordDto.Id;
            updatepassword.Password = updatepasswordDto.Password;
            updatepassword.oldPassword = updatepasswordDto.oldPassword;
            return updatepassword;
        }
    }
}

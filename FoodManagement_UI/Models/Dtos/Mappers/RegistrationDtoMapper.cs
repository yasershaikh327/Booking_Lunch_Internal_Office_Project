using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface IRegistrationDtoMapper
    {
        RegistrationDto Map(Registration registration);
    }
    public class RegistrationDtoMapper : IRegistrationDtoMapper
    {
        public RegistrationDto Map(Registration registration)
        {
           var registrationDto = new RegistrationDto();
            registrationDto.Id = registration.Id;
            registrationDto.Name = registration.Name;
            registrationDto.Email = registration.Email; 
            registration.Password = registration.Password;
            return registrationDto;
        }
    }
}

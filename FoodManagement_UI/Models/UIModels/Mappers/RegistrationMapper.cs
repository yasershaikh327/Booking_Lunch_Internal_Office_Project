using FoodManagement_UI.Models.Dtos;

namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface IRegistrationMapper
    {
        Registration Map(RegistrationDto registrationDto);
        List<Registration> Map(List<RegistrationDto> registrationDto);
    }
    public class RegistrationMapper : IRegistrationMapper
    {
        public Registration Map(RegistrationDto registrationDto)
        {
           var registration = new Registration();
            registration.Id = registrationDto.Id;
            registration.Name = registrationDto.Name;
            registration.Email = registrationDto.Email; 
            registration.Password = registrationDto.Password;
            return registration;
        }

        public List<Registration> Map(List<RegistrationDto> registrationDto)
        {
            var registrationDtoS = new List<Registration>();
            foreach (var dto in registrationDto)
            {
                var registrationItem = new Registration
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password
                };

                registrationDtoS.Add(registrationItem);
            }
            return registrationDtoS;
        }
    }
}

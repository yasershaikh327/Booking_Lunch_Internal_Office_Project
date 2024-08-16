namespace FoodManagement_UI.Models.Dtos
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegistrationDtos
    {
        RegistrationDto registrationDto { get; set; }
        public RegistrationDtos()
        {
            registrationDto = new RegistrationDto();
        }
    }
}

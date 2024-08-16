using FoodInventoryManagement.DataAccess;
using FoodManagement_UI.Helpers;
using FoodManagement_UI.Models.Dtos.Mappers;
using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Models.UIModels.Mappers;



namespace FoodManagement_UI.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FoodManagementDB _dbContext;
        private readonly IFeedbackDtoMapper _feedbackDtoMapper;
        private readonly IFeedbackMapper _feedbackMapper;
        private readonly IRegistrationDtoMapper _registrationDtoMapper;
        private readonly IRegistrationMapper _registrationMapper;
        private readonly IBookmapper _bookmapper;
        private readonly IHelper _helper;

        public EmployeeRepository(FoodManagementDB foodManagementDB, IFeedbackDtoMapper feedbackDto, IHelper helper, IRegistrationDtoMapper registrationDtoMapper,IFeedbackMapper feedbackMapper, IRegistrationMapper registrationMapper, IBookmapper bookmapper)
        {
            _dbContext = foodManagementDB;
            _feedbackDtoMapper = feedbackDto;
            _helper = helper;
            _registrationDtoMapper = registrationDtoMapper;
            _feedbackMapper = feedbackMapper;
            _registrationMapper = registrationMapper;
            _bookmapper = bookmapper;
        }

        //Give Feedback
        public bool GiveFeedback(Feedback feedback)
        {
            var feedbackData = _feedbackDtoMapper.Map(feedback);
            {
                _dbContext.FeedbackDto.Add(feedbackData);
                _dbContext.SaveChanges();
                return true;
            }
        }

        //Verify Email
        public bool VerifyEmailProcess(VerifyEmail verifyEmail)
        {
            var result = _dbContext.RegistrationDto.Any(email => email.Email == verifyEmail.Email);
            if (result)
                return true;
            return false;
        }

        //Registration
        public bool GetRegistration(Registration registration)
        {
            var RegistrationDTo = _registrationDtoMapper.Map(registration);
            {            
                RegistrationDTo.Password = _helper.Base64Encode(registration.Password);
                _dbContext.RegistrationDto.Add(RegistrationDTo);
                _dbContext.SaveChanges();
                return true;
            }
        }

        //Login
        public int LoginProcess(Login login)
        {
            var user = _dbContext.RegistrationDto.FirstOrDefault(u =>
            u.Email == login.Email &&
            u.Password ==  _helper.Base64Encode(login.Password).ToString());
            if (user != null)
                return user.Id;
            return -1;
        }

        //Reset ForgetPassword
        public bool CheckIfMailExists(string Email)
        {
            bool VerifyEmailSuccessful = _dbContext.RegistrationDto
              .Any(b => b.Email == Email);
            if (VerifyEmailSuccessful)
                return true;
            return false;
        }

        public void UpdatePassWord(string Email,string randompassword)
        {
            //Updating Password in Database
            var result = _dbContext.RegistrationDto.FirstOrDefault(r => r.Email == Email);
            if (result != null) 
                 result.Password = _helper.Base64Encode(randompassword);
                _dbContext.SaveChanges();
        }

        //Fetch Feedback
        public List<Feedback> DisplayFeedback()
        {
            var feedbackDto = _dbContext.FeedbackDto.ToList();
            return _feedbackMapper.Map(feedbackDto);
        }


        //Fetch Bookings
        public List<Book> FetchBookings()
        {
            var bookDto = _dbContext.BookLunchDto.ToList(); 
            return _bookmapper.Map(bookDto);
        }

        //Remove Employee
        public void RemoveRegistration(int Id)
        {
            var CheckEmployeeBookedLunch = _dbContext.BookLunchDto.FirstOrDefault(x => x.Employee == Id.ToString());
            var CheckIfIDExists = _dbContext.RegistrationDto.Find(Id);
            if (CheckEmployeeBookedLunch != null && CheckIfIDExists!= null)
            {
                _dbContext.BookLunchDto.Remove(CheckEmployeeBookedLunch);
                _dbContext.RegistrationDto.Remove(CheckIfIDExists);
                _dbContext.SaveChanges();
            }
            _dbContext.RegistrationDto.Remove(CheckIfIDExists);
            _dbContext.SaveChanges();
        }

        //Fetch All Employee Details
        public List<Registration> GetAllEmployees()
        {
            var EmployeesDto = _dbContext.RegistrationDto.ToList();
            return _registrationMapper.Map(EmployeesDto);
        }


        //Check for Old Password
        public bool OldPassword(Updatepassword updatepassword)
        {
            var user = _dbContext.RegistrationDto.FirstOrDefault(b =>
              b.Id == updatepassword.Id &&
              b.Password == _helper.Base64Encode(updatepassword.Password));
            bool isCorrectPassword = user != null;
            return isCorrectPassword;
        }

        //Update Password
        public bool Updatepassword(Updatepassword updatepassword)
        {
            var registration = _dbContext.RegistrationDto.FirstOrDefault(b => b.Id == updatepassword.Id);
            if (registration != null)
                registration.Password = _helper.Base64Encode(updatepassword.Password);
                _dbContext.SaveChanges();
            return true;
        }
    }
}

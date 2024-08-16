using FoodManagement_UI.Helpers;
using FoodManagement_UI.MemoryManagement;
using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Repository;
using FoodManagement_UI.Services;
using Microsoft.AspNetCore.Mvc;



namespace FoodManagement_UI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<EmployeeApiController> _logger;
        private readonly IEmailService _emailService;
        private readonly IOtpManagment _otpManagment;
        private readonly IHelper _helper;
        public EmployeeApiController(ILogger<EmployeeApiController> logger, IEmployeeRepository employeeRepository, IHelper helper, IBookRepository bookRepository, IEmailService emailService, IOtpManagment otpManagment)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _helper = helper;
            _bookRepository = bookRepository;
            _emailService = emailService;
            this._otpManagment = otpManagment;
        }


        //Give Feedback
        [HttpPost]
        public bool UserGiveFeedback(Feedback feedback)
        {
            var result = _employeeRepository.GiveFeedback(feedback);
            if (result)
                return true;
            return false;
        }

        //Verify Email
        [HttpPost]
        public bool ConfirmEmail(VerifyEmail verifyEmail)
        {
            var result = _employeeRepository.VerifyEmailProcess(verifyEmail);
            if (!result)
            {
                string otp = _helper.GnerateString();
                _otpManagment.AddOtp(verifyEmail.Email, otp);
                _emailService.ComfirmEmail(verifyEmail.Email, otp);
                return false;
            }
            return true;
        }

        //Verify OTP
        [HttpPost]
        public bool VerifyOTP(OTPPayload oTP)
        {
            var otpStored = _otpManagment.CheckOtp(oTP.Email,oTP.OTPData);
            if (!otpStored)
                return false;
            return true;
        }

        //Registration Process
        [HttpPost]
        public bool Registration(Registration registration)
        {
            var result = _employeeRepository.GetRegistration(registration);
            if (result)
                return true;
            return false;
        }


        //Login Process
        [HttpPost]
        public int ConfirmLogin(Login login)
        {
            int isUserAuthenticated = _helper.IsUserAuthenticated(login);
            if (isUserAuthenticated == -2)
                return -2;
            if (login.Email.Contains("@zapcg.com"))
                return   _employeeRepository.LoginProcess(login);
            return -1;
        }

        //Book Lunch
        [HttpPost]
        public BookingStatus BookLunch(Book book)
        {
            var result = _bookRepository.CheckifLunchisAlreadyBooked(book);
            var time = _helper.TimeStamp();
            if (!result && time)
            {
                _bookRepository.BookLunch(book);
                return BookingStatus.Booked;
            }
            else if (!time)
                return BookingStatus.TimedOut;

            return BookingStatus.PreBooked;
        }

        //Forget Password
        [HttpPost]
        public bool ForgetPassword(string Email)
        {
            var randompassword = _helper.GnerateString();
            if (_employeeRepository.CheckIfMailExists(Email))
            {
                _employeeRepository.UpdatePassWord(Email, randompassword);
                _emailService.ForgetPassWordEmail(Email, randompassword);
                return true;
            }
            return false;
        }

        //Check if Old Password is Correct 
        [HttpPost]
        public bool UpdatePassword(Updatepassword updatepassword)
        {
            if (_employeeRepository.OldPassword(updatepassword)) 
                return _employeeRepository.Updatepassword(updatepassword);
            return false;
        }


    }
}

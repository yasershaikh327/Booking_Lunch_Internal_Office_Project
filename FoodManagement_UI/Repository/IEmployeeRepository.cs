using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Repository
{
    public interface IEmployeeRepository
    {
        public bool GiveFeedback(Feedback feedback);
        public bool VerifyEmailProcess(VerifyEmail verifyEmail);
        public bool GetRegistration(Registration registration);
        public int LoginProcess(Login login);
        public bool CheckIfMailExists(string Email);
        public void UpdatePassWord(string Email, string randompassword);
        public List<Feedback> DisplayFeedback();
        public List<Book> FetchBookings();
        public void RemoveRegistration(int iD);
        public List<Registration> GetAllEmployees();
        public bool OldPassword(Updatepassword updatepassword);
        public bool Updatepassword(Updatepassword updatepassword);
    }
}

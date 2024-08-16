namespace FoodManagement_UI.MemoryManagement
{
    public interface IOtpManagment
    {
        void AddOtp(string email, string value);
        bool CheckOtp(string email, string otpValue);
    }
}
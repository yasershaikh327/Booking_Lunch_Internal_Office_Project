namespace FoodManagement_UI.Services
{
    public interface IEmailService
    {
        public void SendMail(MailMessageSettings mailMessageSettings);
        public void ComfirmEmail(string email, string otp);
        public void BookingComfirmEmail(string email, bool typeSelection, string name, int id, string date);
        public void CountLunch(int VegCount,int NonVegCount,int TotalCount);
        public void ForgetPassWordEmail(string email, string randompassword);
         
    }
}